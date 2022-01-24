﻿using LetsGo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LetsGo.Core.Entities;
using LetsGo.Core.Entities.Enums;
using LetsGo.DAL;
using LetsGo.UI.Extensions;
using LetsGo.UI.Services;
using LetsGo.UI.ViewModels;
using LetsGo.Enums;

namespace LetsGo.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        private readonly EventsService _service;
        private readonly CabinetService _cabService;
        private readonly UsersService _usersService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public CabinetController(EventsService service, CabinetService cabService,
            ApplicationDbContext context, UserManager<User> userManager)
        {
            _service = service;
            _cabService = cabService;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile(Status Status, DateTime DateTimeFrom, DateTime DateTimeBefore,
            string selectedCategories, SortState SortOrder = SortState.DateStartDesc)
        {
            List<int> EventCategories = new List<int>();
            if (!string.IsNullOrEmpty(selectedCategories))
                EventCategories = selectedCategories.Split(',').Select(c => int.Parse(c)).ToList();

            User user = _context.Users.FirstOrDefault(u => u.Id == _userManager.GetUserIdAsInt(User));
            ProfileViewModel viewModel = new ProfileViewModel { User = user };
            viewModel.CategoriesDictionary = _context.EventCategories.ToArray()
                .GroupBy(c => c.ParentId).ToDictionary(g => g.Key.HasValue ? g.Key : -1, g => g.ToList());
            Dictionary<string, Status> Stats = _cabService.GetDictionaryStats();
            viewModel.Stats = Stats;
            viewModel.EventCategories = _context.EventCategories.ToList();
            viewModel.selectedCategories = selectedCategories ?? String.Empty;

            IQueryable<Event> Events = _cabService.QueryableEventsAfterFilter(
                EventCategories, Status, DateTimeFrom, DateTimeBefore
            );

            ViewBag.NameSort = SortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewBag.PriceSort = SortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            ViewBag.DateStartSort = SortOrder == SortState.DateStartAsc ? SortState.DateStartDesc : SortState.DateStartAsc;
            switch (SortOrder)
            {
                case SortState.NameDesc:
                    Events = Events.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    Events = Events.OrderBy(s => s.MinPrice);
                    break;
                case SortState.PriceDesc:
                    Events = Events.OrderByDescending(s => s.MinPrice);
                    break;
                case SortState.DateStartAsc:
                    Events = Events.OrderBy(s => s.EventStart);
                    break;
                case SortState.DateStartDesc:
                    Events = Events.OrderByDescending(s => s.EventStart);
                    break;
                default:
                    Events = Events.OrderBy(s => s.Name);
                    break;
            }

            viewModel.Events = Events.ToList();

            List<User> allUsers = new List<User>();
            if (User.IsInRole("superadmin"))
                allUsers.AddRange(await _userManager.GetUsersInRoleAsync("admin"));
            allUsers.AddRange(await _userManager.GetUsersInRoleAsync("organizer"));
            allUsers.AddRange(await _userManager.GetUsersInRoleAsync("usher"));

            viewModel.Users = allUsers;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            var model = new EditProfileViewModel()
            {
                Id = id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                SelfInfo = user.SelfInfo
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditProfileViewModel userModel)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == userModel.Id);
            if (currentUser == null) return RedirectToAction("Profile");
            string avatar;
            if (userModel.Avatar == null)
            {
                avatar = currentUser.AvatarLink;
            }
            else
            {
                avatar = "/avatars/" + EventsService.GenerateCode() + Path.GetExtension(userModel.Avatar.FileName);
                using (var fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + avatar), FileMode.Create))
                    await userModel.Avatar.CopyToAsync(fileStream);
            }
            bool newEmail = currentUser.Email != userModel.Email;
            if (newEmail) currentUser.EmailConfirmed = false;

            currentUser.Email = userModel.Email;
            currentUser.UserName = userModel.UserName;
            currentUser.PhoneNumber = userModel.PhoneNumber;
            currentUser.AvatarLink = avatar;
            currentUser.SelfInfo = userModel.SelfInfo;

            _context.Users.Update(currentUser);
            await _context.SaveChangesAsync();
            if (newEmail)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(currentUser);
                await SendConfirmEmail(currentUser, code);
                // выходить из аккаунта
                //return RedirectToAction("Account", "Logout", null);
            }
            return RedirectToAction("Profile");
        }

        public async Task SendConfirmEmail(User user, string code)
        {
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);
            await EmailService.Send(user.Email, "Подтвердите ваш аккаунт",
                $"Подтвердите регистрацию, перейдя по ссылке:" +
                $" <a href='{callbackUrl}'>ссылка</a>");
        }

        public async Task Approve(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //user.Approved = true;
            //_context.SaveChanges();
            await SendConfirmEmail(user, code);
        }

        public async Task DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (_context.Events.Any(u => u.OrganizerId == user.Id && u.Status == Status.Published))
            {
                foreach (var item in _service.GetEvents(user.Id).Result.Where(e => e.Status == Status.Published))
                {
                    await _service.ChangeStatus("UnPublished", item.Id, "The organizer of the event was deleted by admin");
                }
            }
            if (user.EmailConfirmed)
            {
                await EmailService.Send(user.Email, "Ваша учетная запись была удалена",
                    $"Доброго времени суток, {user.UserName}! Ваша учетная запись на сайте ticketbox.store была удалена" +
                    $"по определенным причинам.");
            }
            else
            {
                await EmailService.Send(user.Email, "Ваша заявка на создание учетной записи была отклонена",
                    $"Доброго времени суток, {user.UserName}! Ваша заявка на создание учетной записи была отклонена," +
                    $"так как администрация сайта сочла ваши данные недостоверными или по каким-либо иным причинам.");
            }
            var rolesForUser = await _userManager.GetRolesAsync(user);

            using (var transaction = _context.Database.BeginTransaction())
            {
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, item);
                    }
                }
                await _userManager.DeleteAsync(user);
                transaction.Commit();
            }
        }
    }
}
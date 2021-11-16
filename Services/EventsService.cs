﻿using LetsGo.Models;
using LetsGo.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LetsGo.Services
{
    public class EventsService
    {
        private readonly LetsGoContext _goContext;
        private IMemoryCache cache;

        public EventsService(LetsGoContext goContext, IMemoryCache cache)
        {
            _goContext = goContext;
            this.cache = cache;
        }

        public async Task<Event> AddEvent(AddEventViewModel eventView)
        {
            string name = GenerateCode() + '.'+ Path.GetExtension(eventView.File.FileName);
            string pathImage = "/posters/" + name;
            using (var fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + pathImage), FileMode.Create))
                await eventView.File.CopyToAsync(fileStream);

            string jsonCateg = string.Empty;
            jsonCateg = eventView.Categories != null ? JsonSerializer.Serialize(eventView.Categories) : "";

            Event @event = new Event
            {
                Name = eventView.Name,
                Description = eventView.Description,
                CreatedAt = DateTime.Now,
                EventStart = eventView.EventStart,
                EventEnd = eventView.EventEnd,
                PosterImage = pathImage,
                Categories = jsonCateg,
                AgeLimit = Convert.ToInt32(eventView.AgeLimit),
                TicketLimit = eventView.TicketLimit,
                LocationId = _goContext.Locations.FirstOrDefault(l => l.Name == eventView.Location).Id
            };
            await _goContext.Events.AddAsync(@event);
            await _goContext.SaveChangesAsync();
            cache.Set(@event.Id, @event, new MemoryCacheEntryOptions());
            
            return @event;
        }

        public async Task<List<EventTicketType>> AddEventTicketTypes(string eventId, List<EventTicketType> ticketTypes)
        {
            foreach (var item in ticketTypes)
            {
                item.EventId = eventId;
                item.Sold = 0;
                _goContext.EventTicketTypes.Add(item);
                cache.Set(item.Id, item, new MemoryCacheEntryOptions());
            }
            await _goContext.SaveChangesAsync();

            return ticketTypes;

        }

        public static string GenerateCode()
        {
            StringBuilder builder = new StringBuilder(6);
            Random random = new Random();
            for (var i = 1; i <= 12; i++)
            {
                builder.Append(random.Next(10));
            }
            string UC = builder.ToString();
            return UC;
        }
    }
}
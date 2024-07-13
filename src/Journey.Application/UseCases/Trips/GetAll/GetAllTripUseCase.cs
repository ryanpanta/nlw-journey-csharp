﻿using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Journey.Application.UseCases.Trips.GetAll
{
    public class GetAllTripUseCase
    {
        public ResponseTripsJson Execute()
        {

            var dbContext = new JourneyDbContext();

            var trips = dbContext.Trips.ToList();

            return new ResponseTripsJson
            {
                Trips = trips.Select(trip => new ResponseShortTripJson
                {
                    Id = trip.Id,
                    StartDate = trip.StartDate,
                    EndDate = trip.EndDate,
                    Name = trip.Name
                }).ToList()

            };
        }
    }
}

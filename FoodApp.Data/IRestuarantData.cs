﻿using FoodApp.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace FoodApp.Data
{
    public interface IRestuarantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }
    public class InMemoryRestaurantData : IRestuarantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Burrito Loco", Location="Texas", Cuisine=CuisineType.Mexican},
                new Restaurant { Id = 3, Name = "India Garden", Location="Illinois", Cuisine=CuisineType.Indian},
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}

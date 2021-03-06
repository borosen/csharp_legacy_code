﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieRentals
{
    internal class Pricer
    {
        public static Movie Price(string imdbId)
        {
            async Task<ImdbMovie> Json()
            {
                HttpResponseMessage response = await new HttpClient().GetAsync("http://www.omdbapi.com/?i=" + imdbId + "&apikey=6487ec62");

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<ImdbMovie>(json);
            }


            ImdbMovie imdbMovie = Json().Result;

            double price = 3.95;

            double rating = Double.Parse(imdbMovie.imdbRating);
            
            if(rating > 7.0)
                price += 1.0;

            if (rating < 4)
                price -= 1.0;
            
            return new Movie(imdbMovie.Title, price);
        }
    }
}
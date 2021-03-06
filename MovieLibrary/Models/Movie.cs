﻿using Newtonsoft.Json;

namespace MovieLibrary.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rated")]
        public double Rated { get; set; }
    }
}

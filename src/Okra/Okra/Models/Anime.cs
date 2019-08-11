using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Okra.Models
{
    public class Anime : BaseModel
    {
        public static Anime Create(
            string id
            , string mal_id
            , string title
            , string year
            , string slug
            , string type
            , List<string> genres
            , string genresConcat
            , Images images
            , Rating rating
            , int num_seasons)
            => new Anime
            {
                _id = id,
                mal_id = mal_id,
                title = title,
                year = year,
                slug = slug,
                type = type,
                genres = genres,
                genresConcat = genresConcat + string.Join(",",genres.ToArray()),
                images = images,
                rating = rating,
                num_seasons = num_seasons
            };

        public string _id { get; set; }
        public string mal_id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public List<string> genres { get; set; }

        public string genresConcat { get; set; }
        public Images images { get; set; }
        public Rating rating { get; set; }
        public int num_seasons { get; set; }
    }
    public class Images
    {
        public string poster { get; set; }
        public string fanart { get; set; }
        public string banner { get; set; }
    }

    public class Rating
    {
        public int percentage { get; set; }
        public int watching { get; set; }
        public int votes { get; set; }
        public int loved { get; set; }
        public int hated { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Okra.Models
{
    public sealed class Recipe : BaseModel
    {
        public string Title { get; set; }
        public string Steps { get; set; }
        public List<Picture> Pictures { get; set; }
        public Author Author { get; set; }

        public static Recipe Create(string title
            , string steps
            , List<Picture> pictures
            , Author author)
            => new Recipe
            {
                Title = title,
                Steps = steps,
                Pictures = pictures,
                Author = author
            };
    }
}

﻿namespace JamieWroeDotCom.Models
{
    using System;
    using System.Collections.Generic;

    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ImageName { get; set; }
        public string Blurb { get; set; }
        public IEnumerable<String> Keywords { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastEdited { get; set; }

    }

    public enum Status
    {

        Draft,
        Published,
        Deleted

    }
}
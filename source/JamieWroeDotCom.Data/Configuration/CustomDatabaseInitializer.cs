using System;
using System.Data.Entity;
using System.Linq;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration
{
    public class CustomDatabaseInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        private const string FirstPostString = "<h3>My first post :)</h3><p>Well, this is the first post for the new site. I don't actually have much of anything on my site right now, in fact I'm typing all this into a string literal inside the Entity Framework seed method!</p>" +
                                               "<p>I've also just finished writing the <code>Post</code> and <code>User</code> configuration files for <acronym title='Entity Framework'>EF</acronym>. Since I've gone for a code first approach I needed to be a little specific with to make sure my tables are all setup correctly. For example, the <code>Post</code> (which represents a single blog entry) has a content property. That property is what stores the (HTML encoded) text you're reading right now. Since a given post can really be any arbriatary length I want to make sure EF stores them as the datatype LONGTEXT, luckily however this happens to be trivial to do. ";

        protected override void Seed(DataContext context)
        {
            if (!context.Posts.Any(post => post.Content == FirstPostString))
            {
                context.Posts.Add(new Post
                                  {
                                      Title = "Awaken.... Awaken and hear me....",
                                      Content = FirstPostString,
                                      CreationDate = DateTime.Now
                                  });
            }
            base.Seed(context);
        }
    }
}
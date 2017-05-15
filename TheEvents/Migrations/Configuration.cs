namespace TheEvents.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheEvents.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheEvents.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheEvents.Models.ApplicationDbContext context)
        {
            var OwnerRole = "owner";
            var townHall = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(townHall);

            if (!context.Roles.Any(a => a.Name == OwnerRole))
            {
                var role = new IdentityRole { Name = OwnerRole };
                manager.Create(role);
            }

            var ownerEmail = "owner@event.com";
            var defaultPassword = "Password1!";
            if (!context.Users.Any(u => u.UserName == ownerEmail))
            {
                var userTownHall = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userTownHall);
                var user = new ApplicationUser { UserName = ownerEmail };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, OwnerRole);
            }


            var concert = new Genres { Title = "Consert" };

            context.Genres.AddOrUpdate(g => g.Title, concert);

            var venue = new Venues { Title = "TheBestVenue " };
            context.Venues.AddOrUpdate(v => v.Title, venue);
            context.SaveChanges();

            var es = new List<Events>
            {
                   new Events{Title ="The Band", VenuesId = venue.Id, GenreId = concert.Id, StartTime = DateTime.Now},


                new Events{Title ="White Horse", VenuesId = venue.Id, GenreId = concert.Id,StartTime = DateTime.Now},


                new Events{Title ="Purple Dragons", VenuesId = venue.Id, GenreId = concert.Id,StartTime = DateTime.Now},


                new Events{Title ="The Best Reggae Ever", VenuesId = venue.Id, GenreId = concert.Id, StartTime = DateTime.Now},
            };

            es.ForEach(ent => context.Events.AddOrUpdate(e => e.Title, ent));
            context.SaveChanges();

        }
    }
}

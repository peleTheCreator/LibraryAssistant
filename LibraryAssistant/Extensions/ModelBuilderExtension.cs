using LibraryAssistant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;


namespace LibraryAssistant.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().HasData(
                 new Books
                 {
                     Id = 1,
                     Status = true,
                     CoverPrice = 989.05M,
                     ISBN = "986-3-16-148410-0",
                     PublishYear = 1994,
                     Title = "To Kill a MockingBird"
                 },
                 new Books
                 {
                     Id = 2,
                     Status = true,
                     CoverPrice = 589.05M,
                     ISBN = "886-3-16-148410-0",
                     PublishYear = 2004,
                     Title = "The Great GatsBy"

                 },
                 new Books
                 {
                     Id = 3,
                     Status = true,
                     CoverPrice = 300.05M,
                     ISBN = "686-3-16-148410-0",
                     PublishYear = 2002,
                     Title = "The Lion King"
                 },
                 new Books
                 {
                     Id = 4,
                     Status = true,
                     CoverPrice = 350.05M,
                     ISBN = "586-3-16-148410-0",
                     PublishYear = 2001,
                     Title = "The Book of THief"
                 },
                 new Books
                 {
                     Id = 5,
                     Status = true,
                     CoverPrice = 278.05M,
                     ISBN = "699-3-16-148410-0",
                     PublishYear = 1997,
                     Title = "Harry Porter"
                 },
                   new Books
                   {
                       Id = 6,
                       Status = true,
                       CoverPrice = 778.05M,
                       ISBN = "199-3-16-148410-0",
                       PublishYear = 1976,
                       Title = "Gone with the wind"
                   },
                    new Books
                    {
                        Id = 7,
                        Status = true,
                        CoverPrice = 798.05M,
                        ISBN = "779-3-16-148410-0",
                        PublishYear = 2012,
                        Title = "Lord of files"
                    },
                     new Books
                     {
                         Id = 8,
                         Status = true,
                         CoverPrice = 778.05M,
                         ISBN = "199-3-16-148410-0",
                         PublishYear = 1976,
                         Title = "OF Mice and Men"
                     }                
                );


            modelBuilder.Entity<Users>().HasData(
                     new Users
                     {
                         Id = 1,
                         Email = "ade@gmail.com",
                         FullName ="ade olawale",
                         NIN = "6778 8999 9090 7689",
                         PhoneNumber = "08036279679"
                     },
                      new Users
                      {
                          Id = 2,
                          Email = "mark@gmail.com",
                          FullName = "mark micheal",
                          NIN = "3478 8999 9090 7689",
                          PhoneNumber = "08096279679"
                      },
                       new Users
                       {
                           Id = 3,
                           Email = "pelumi@gmail.com",
                           FullName = "pelumi salami",
                           NIN = "2478 8999 9090 7689",
                           PhoneNumber = "08026279679"
                       }
                );

            modelBuilder.Entity<BooksActivity>().HasData(
                     new BooksActivity
                     {
                         Id = 1,
                         BooksId = 1,
                         UsersId = 1,
                         CheckOut = DateTime.Now,
                         RetUrnDays = 10,
                         ExpectedCheckIn = DateTime.Now.AddBusinessDays(10),
                     }
                );


















        }
    }
}

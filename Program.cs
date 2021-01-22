using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();

            var albumCount = context.Albums.Count();
            Console.WriteLine($"There are {albumCount} albums!");

            // CODE STARTS HERE

            Console.WriteLine("Welcome to Rhythms Gonna Get You Records Database:");

            var userChoice = false;

            while (userChoice == false)
            {

                Console.WriteLine("\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("\n");
                Console.WriteLine("View");
                Console.WriteLine("Current Clients");
                Console.WriteLine("Add");
                Console.WriteLine("Change Contract");
                Console.WriteLine("Quit");
                Console.WriteLine("\n");

                var menuChoice = Console.ReadLine().ToLower().Trim();

                switch (menuChoice)
                {
                    case "view":
                        Console.WriteLine("\n\n");
                        Console.WriteLine("View Options:");
                        Console.WriteLine("\n");
                        Console.WriteLine("All Bands");
                        Console.WriteLine("All Albums");
                        Console.WriteLine("Band Albums");
                        Console.WriteLine("\n");

                        var viewChoice = Console.ReadLine().ToLower().Trim();
                        switch (viewChoice)
                        {
                            case "all bands":
                                foreach (var band in context.Bands)
                                {
                                    Console.WriteLine($"{band.Name}");
                                }
                                break;

                            case "all albums":
                                foreach (var album in context.Albums.OrderBy(albums => albums.ReleaseDate))
                                {
                                    Console.WriteLine($"{album.Title}");
                                }
                                break;


                            case "band albums":
                                Console.Write("What band are you looking for?");
                                var bandChoice = Console.ReadLine().Trim();

                                foreach (var album in context.Albums.Include(band => band.BandSelected.Name == bandChoice))
                                {
                                    Console.WriteLine($"The albums for {bandChoice} are {album.Title}");

                                }
                                break;
                        }
                        break;

                    case "current clients":

                        // -var bandToResign = Ask which band you want to resign
                        //  -var resignBand = context.Band.FirstOrDefault(band => band.Name == bandToResign)
                        //  - if (resignBand == Null)
                        //    -Sorry no band found
                        //      - Else
                        //   - resignBand.IsSigned = True
                        break;



                    case "change contract":

                        Console.WriteLine("\n");
                        Console.WriteLine("Current Client Menu:");
                        Console.WriteLine("\n");
                        Console.WriteLine("Resign a Band");
                        Console.WriteLine("Let a Band go");
                        Console.WriteLine("\n");

                        var contractOptions = Console.ReadLine().ToLower().Trim();

                        if (contractOptions == "resign a band")
                        {
                            Console.Write("Which band do you want to resign?");

                            var bandToResign = Console.ReadLine().ToLower().Trim();

                            var resignBand = context.Bands.FirstOrDefault(band => band.Name.ToLower() == bandToResign);
                            if (resignBand != null)
                            {
                                resignBand.IsSigned = true;
                                context.SaveChanges();
                            }
                            else
                            {
                                Console.WriteLine("Sorry your band name was not found");
                            }
                        }

                        if (contractOptions == "let a band go")
                        {
                            Console.Write("Which band do you want to let go?");

                            var bandToLetGo = Console.ReadLine().ToLower().Trim();

                            var letGoBand = context.Bands.FirstOrDefault(band => band.Name.ToLower() == bandToLetGo);
                            if (letGoBand != null)
                            {
                                letGoBand.IsSigned = true;
                                context.SaveChanges();
                            }
                            else
                            {
                                Console.WriteLine("Sorry your band name was not found");
                            }

                        }

                        break;



                }

            }
        }
    }
}

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

            foreach (var band in context.Bands)
            {
                Console.WriteLine($"There is a movie named {band.Name}");
            }
            // CODE STARTS HERE

            Console.WriteLine("Welcome to Rhythms Gonna Get You Records Database:");

            var userChoice = false;

            while (userChoice == false)
            {

                Console.WriteLine("\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("View");
                Console.WriteLine("Current Clients");
                Console.WriteLine("Add");
                Console.WriteLine("Contract Change");
                Console.WriteLine("Quit");

                var menuChoice = Console.ReadLine().ToLower().Trim();

                switch (menuChoice)
                {
                    case "View":
                        Console.WriteLine("View Options:");
                        Console.WriteLine("All Bands");
                        Console.WriteLine("Band Albums");
                        Console.WriteLine("Albums by Band");

                        var viewChoice = Console.ReadLine().ToLower().Trim();
                        switch (viewChoice)
                        {
                            case "All Bands":


                                break;
                        }




                        break;

                }




                //                 - View
                //     - All bands
                //     - Band Albums
                //     - Album by Band
                //   -Current Clients
                //    - Signed
                //    - Not Signed
                //  - Add
                //    - Add album for a band

                //    -Add a song to album
                //  - Contract change
                //    - Let band go
                //    - Resign a Band
                //  - Quit



            }






        }
    }
}

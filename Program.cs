using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        public static void Greeting(string message)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("--------------------------------------------");
        }

        public static string ReadInput(string message)
        {
            Console.Write(message);
            var input = Console.ReadLine().ToLower().Trim();
            return input;
        }
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();
            Greeting("Welcome to Rhythms Gonna Get You Records Database:");

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
                Console.WriteLine("Which choice would you like? \n");

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
                        Console.WriteLine("Albums In Genre");
                        Console.WriteLine("Members in Band");
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
                                var bandChoice = ReadInput("What band are you looking for?\n");


                                Console.WriteLine($"\nThe Albums in {bandChoice} are:");
                                foreach (var album in context.Albums.Where(band => band.BandSelected.Name.ToLower() == bandChoice))
                                {
                                    Console.WriteLine(album.Title);

                                }
                                break;
                            case "albums in genre":
                                var genreChoice = ReadInput("What genre are you looking for?\n");

                                var albumsInGenre = context.Albums.Where(genre => genre.BandSelected.Style.ToLower() == genreChoice);

                                if (albumsInGenre != null)
                                {
                                    Console.WriteLine($"\nThe Albums in {genreChoice} are:");
                                    foreach (var album in context.Albums.Where(genre => genre.BandSelected.Style.ToLower() == genreChoice))
                                    {
                                        Console.WriteLine(album.Title);

                                    }

                                }

                                if (albumsInGenre == null)
                                {
                                    Console.WriteLine($"I am sorry we dont have any albums in the genre {genreChoice}");
                                }

                                break;
                            case "members in band":
                                var bandNameChoice = ReadInput("What band are you looking for?");


                                Console.WriteLine($"\nThe members in {bandNameChoice} are:\n");
                                foreach (var band in context.Bands.Where(band => band.Name.ToLower() == bandNameChoice).Include(band => band.BandMembers).ThenInclude(name => name.Musician))
                                {
                                    foreach (var musician in band.BandMembers)
                                    {
                                        Console.WriteLine($"{musician.Musician.FullName}");
                                    }
                                }
                                break;
                        }
                        break;

                    case "current clients":
                        var contractStatus = ReadInput("Would you like to see signed bands or not signed?");

                        if (contractStatus == "signed")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Signed Bands:");
                            foreach (var signed in context.Bands.Where(band => band.IsSigned == true))
                            {
                                Console.WriteLine(signed.Name);
                            }
                        }
                        if (contractStatus == "not signed")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Not Signed Bands:");
                            foreach (var notSigned in context.Bands.Where(band => band.IsSigned == false))
                            {
                                Console.WriteLine(notSigned.Name);
                            }
                        }
                        // else
                        // {
                        //     Console.WriteLine("I am sorry, your enter is invalid");
                        // }

                        break;

                    case "add":

                        Console.WriteLine("\n");
                        Console.WriteLine("Add Menu:");
                        Console.WriteLine("Add a new Band");
                        Console.WriteLine("Add Album to a Band");
                        Console.WriteLine("Add song to a Album");
                        Console.WriteLine("\n");

                        var addOptions = Console.ReadLine().ToLower().Trim();

                        if (addOptions == "add a new band")
                        {
                            var newBandName = ReadInput("What is the name of your new band?");

                            var newCountry = ReadInput("What is the Country of Origin? ");

                            var newMemberNum = int.Parse(ReadInput("How many members are in the group? "));

                            var newWebsite = ReadInput("What is the website of your band? ");

                            var newStyle = ReadInput("What style is your band? ");

                            var newSigned = bool.Parse(ReadInput("Is your band signed (true or false)? "));

                            var newContact = ReadInput("What is the contact name for your band? ");

                            var newPhone = ReadInput("What is the contact phone number? ");

                            var newBand = new Band()

                            {
                                Name = newBandName,
                                CountryOfOrigin = newCountry,
                                NumberOfMembers = newMemberNum,
                                Website = newWebsite,
                                Style = newStyle,
                                IsSigned = newSigned,
                                ContactName = newContact,
                                ContactPhoneNumber = newPhone
                            };

                            context.Bands.Add(newBand);

                            context.SaveChanges();
                        }


                        if (addOptions == "add album to a band")
                        {
                            var bandName = ReadInput("Which band would you like to add to? ");
                            var bandPicked = context.Bands.FirstOrDefault(band => band.Name.ToLower() == bandName);

                            var newTitle = ReadInput("What is the title of the album? ");

                            var newIsExplicit = bool.Parse(ReadInput("Is the album Explicit ? "));

                            var newReleaseDate = DateTime.Parse(ReadInput("What is the release date of the Album? "));

                            var newAlbum = new Album()

                            {

                                Title = newTitle,
                                IsExplicit = newIsExplicit,
                                ReleaseDate = newReleaseDate,
                                BandId = bandPicked.Id
                            };

                            context.Albums.Add(newAlbum);

                            context.SaveChanges();
                        }

                        if (addOptions == "add song to a album")
                        {
                            var albumName = ReadInput("Which album would you like to add to? ");
                            var albumPicked = context.Albums.FirstOrDefault(album => album.Title.ToLower() == albumName);

                            var newTrackNumber = int.Parse(ReadInput("What is the track of the song you would like to add? "));

                            var newTitle = ReadInput("What the title of the song? ");

                            var newDuration = int.Parse(ReadInput("How long is the song? "));

                            var newSong = new Song()

                            {
                                Title = newTitle,
                                TrackNumber = newTrackNumber,
                                Duration = newDuration,
                                AlbumId = albumPicked.Id
                            };

                            context.Songs.Add(newSong);

                            context.SaveChanges();
                        }

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
                            var bandToResign = ReadInput("Which band do you want to resign? ");

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
                            var bandToLetGo = ReadInput("Which band do you want to let go?");

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

                    case "quit":
                        userChoice = true;

                        break;




                }


            }
            Greeting("Thank you for visiting Rhythms Gonna Get You Records");
        }
    }
}

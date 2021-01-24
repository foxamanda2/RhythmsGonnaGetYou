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

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Welcome to Rhythms Gonna Get You Records Database:");
            Console.WriteLine("--------------------------------------------");

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
                                Console.Write("What band are you looking for?\n");
                                var bandChoice = Console.ReadLine().Trim().ToLower();

                                Console.WriteLine($"\nThe Albums in {bandChoice} are:");
                                foreach (var album in context.Albums.Where(band => band.BandSelected.Name.ToLower() == bandChoice))
                                {
                                    Console.WriteLine(album.Title);

                                }
                                break;
                            case "albums in genre":
                                Console.Write("What genre are you looking for?\n");
                                var genreChoice = Console.ReadLine().Trim().ToLower();

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
                                Console.Write("What band are you looking for?");
                                var bandNameChoice = Console.ReadLine().Trim();


                                Console.WriteLine($"\nThe members in {bandNameChoice} are:\n");
                                foreach (var band in context.Bands.Where(band => band.Name == bandNameChoice).Include(band => band.BandMembers).ThenInclude(name => name.Musician))
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

                        Console.Write($"Would you like to see signed bands or not signed?");

                        var contractStatus = Console.ReadLine().ToLower().Trim();

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
                            Console.WriteLine("What is the name of your new band?");
                            var newBandName = Console.ReadLine();

                            Console.WriteLine("What is the Country of Origin? ");
                            var newCountry = Console.ReadLine();

                            Console.WriteLine("How many members are in the group? ");
                            var newMemberNum = int.Parse(Console.ReadLine());

                            Console.WriteLine("What is the website of your band? ");
                            var newWebsite = Console.ReadLine();

                            Console.WriteLine("What style is your band? ");
                            var newStyle = Console.ReadLine();

                            Console.WriteLine("Is your band signed (true or false)? ");
                            var newSigned = bool.Parse(Console.ReadLine());

                            Console.WriteLine("What is the contact name for your band? ");
                            var newContact = Console.ReadLine();

                            Console.WriteLine("What is the contact phone number? ");
                            var newPhone = Console.ReadLine();

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
                            Console.Write("Which band would you like to add to?");
                            var bandName = Console.ReadLine().Trim().ToLower();
                            var bandPicked = context.Bands.FirstOrDefault(band => band.Name.ToLower() == bandName);

                            Console.Write("What is the title of the album? ");
                            var newTitle = Console.ReadLine();

                            Console.Write("Is the album Explicit? ");
                            var newIsExplicit = bool.Parse(Console.ReadLine());

                            Console.Write("What is the release date of the Album? ");
                            var newReleaseDate = DateTime.Parse(Console.ReadLine());

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
                            Console.Write("Which album would you like to add to?");
                            var albumName = Console.ReadLine().Trim();
                            var albumPicked = context.Albums.FirstOrDefault(album => album.Title == albumName);

                            Console.Write("What is the track of the song you would like to add? ");
                            var newTrackNumber = int.Parse(Console.ReadLine());

                            Console.Write("What the title of the song? ");
                            var newTitle = Console.ReadLine();

                            Console.Write("How long is the song? ");
                            var newDuration = int.Parse(Console.ReadLine());

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

                    case "quit":
                        userChoice = true;

                        break;




                }


            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Thank you for visiting Rhythms Gonna Get You Records");
            Console.WriteLine("--------------------------------------------");
        }
    }
}

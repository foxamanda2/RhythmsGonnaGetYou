# RhythmsGonnaGetYou

#dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# Problem

- A database needs to be created to store Band information, Album information, and Song information.
- C R U D

- Create: Add (create) a new band, new album, and new song.
- Read: Get the list of bands, all albums, and all songs
- Update: Update band information
- Delete: Nothing needs to be removed

# Examples

- The program should allow you to be able to add an album for a band.
- The program should allow you to ass a song to an album
- The program should allow you to view bands signed and not signed
- There should be an option to view all of the bands
- The option to resign a band and sign a band should be added. Should switch from true to false and vice versa.

# Data

## Classes

- RhythmsGonnaGetYou : DbContext

  - DbSet <Album> Albums
  - DbSet <Band> Bands
  - DbSet <Song> Songs

  - protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    - {
    -     optionsBuilder.UseNpgsql("server=localhost;database=RecordCompany");
    - }

- Album

  - Id (INT)
  - Title (STRING)
  - IsExplicit (BOOL)
  - ReleaseDate (DATETIME)
  - BandId (INT)
  - BandSelected (Band)

+------+-------------------+--------------+---------------+----------+
| Id | Title | IsExplicit | ReleaseDate | BandId |
|------+-------------------+--------------+---------------+----------|
| 1 | Relaxer | False | 2017-06-02 | 1 |
| 2 | Man On The Moon 2 | True | 2010-11-09 | 2 |
| 3 | This is all yours | False | 2014-09-22 | 1 |
| 4 | Home Ing | False | 2004-07-22 | 4 |
| 5 | Redhold | True | 2019-12-03 | 5 |
| 6 | Lotlux | False | 1996-08-08 | 6 |
| 7 | Andalax | False | 1992-09-17 | 7 |
| 8 | Fixflex | False | 2008-01-27 | 8 |
| 9 | Zoolab | False | 2014-07-06 | 9 |
| 10 | Sonair | True | 1992-06-18 | 10 |
+------+-------------------+--------------+---------------+----------+

- Band

  - Id (INT)
  - Name (STRING)
  - CountryOfOrigin (STRING)
  - NumberOfMembers (INT)
  - Website (STRING)
  - Style (STRING)
  - IsSigned (BOOL)
  - ContactName (STRING)
  - ContactPhoneNumber (STRING)

+------+-----------------+-------------------+-------------------+---------------------+-------------+------------+---------------------+----------------------+
| Id | Name | CountryOfOrigin | NumberOfMembers | Website | Style | IsSigned | ContactName | ContactPhoneNumber |
|------+-----------------+-------------------+-------------------+---------------------+-------------+------------+---------------------+----------------------|
| 1 | Alt-J | United Kingdom | 2 | unc.edu | Indie | False | Quinton Playfoot | 168-753-8926 |
| 2 | Kid Cudi | United States | 1 | vkontakte.ru | Rap | True | Scott Mescudi | 265-744-4733 |
| 3 | African Snake | Russia | 4 | mayoclinic.com | Rock | True | Coop Fuchs | 397-220-7823 |
| 4 | Desert Tortoise | France | 4 | google.co.jp | Alternative | False | Cherilynn Windridge | 892-141-0002 |
| 5 | Turkey | China | 7 | businessinsider.com | Indie | True | Johann Goodinso | 533-889-8769 |
| 6 | Starfish | China | 5 | w3.org | Country | False | Rik Longfut | 764-138-2031 |
| 7 | Agua | Brazil | 3 | fc2.com | Indie | True | Corliss Bernadzki | 844-947-9772 |
| 8 | Red-necked | Canada | 2 | mozilla.org | Folk | True | Urson Raffles | 165-605-7128 |
| 9 | Bighorn sheep | Japan | 3 | exblog.jp | Pop | False | Riane Jirus | 618-653-2674 |
| 10 | Stork | United States | 4 | hubpages.com | Bluegrass | True | Muhammad Snoxall | 448-365-4451 |
+------+-----------------+-------------------+-------------------+---------------------+-------------+------------+---------------------+----------------------+

- Song

  - Id (INT)
  - Track Number (INT)
  - Title (STRING)
  - Duration (DATETIME)
  - AlbumId (INT)
  - AlbumSelected (Album)

| Id | TrackNumber | Title | Duration | AlbumId |
|------+---------------+-------------------------+------------+-----------|
| 1 | 1 | 3WW | 5 | 1 |
| 2 | 6 | Adeline | 6 | 1 |
| 3 | 3 | Dont Play This Song | 3 | 2 |
| 4 | 2 | REVOFEV | 3 | 2 |
| 5 | 13 | Bos mutus | 3 | 5 |
| 6 | 6 | Vulpes chama | 1 | 6 |
| 7 | 10 | Paraxerus cepapi | 3 | 7 |
| 8 | 1 | Melophus lathami | 2 | 8 |
| 9 | 8 | Canis lupus | 1 | 9 |
| 10 | 1 | Amblyrhynchus cristatus | 3 | 10 |
| 11 | 1 | Chamaelo sp. | 2 | 3 |
| 12 | 3 | Herpestes javanicus | 1 | 4 |
| 13 | 12 | Phoenicopterus ruber | 2 | 7 |
| 14 | 1 | Felis caracal | 3 | 9 |
+------+---------------+-------------------------+------------+-----------+

## Menu

- View
  - All the bands
  - View Bands albums
  - By order Of release Date
- If Band is signed
  - Signed
  - Not Signed
- Add
  - Add album for a band
  - Add a song to album
- Contract Sign Change
  - Let band go
  - Resign a Band
- Quit

# Algorithm

- RhythmsGonnaGetYou : DbContext

  - DbSet <Album> Albums
  - DbSet <Band> Bands
  - DbSet <Song> Songs

  - protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    - {
    -     optionsBuilder.UseNpgsql("server=localhost;database=RecordCompany");
    - }

- Class Album

  - Id (INT)
  - Title (STRING)
  - IsExplicit (BOOL)
  - ReleaseDate (DATETIME)
  - BandId (INT)
  - BandSelected (Band)
  - Do we need a list? **\*\*\*\***

  - Band

  - Id (INT)
  - Name (STRING)
  - CountryOfOrigin (STRING)
  - NumberOfMembers (INT)
  - Website (STRING)
  - Style (STRING)
  - IsSigned (BOOL)
  - ContactName (STRING)
  - ContactPhoneNumber (STRING)

- Song

  - Id (INT)
  - Track Number (INT)
  - Title (STRING)
  - Duration (DATETIME)
  - AlbumId (INT)
  - AlbumSelected (Album)

  - Welcome Line
  - Console.WriteLine "Welcome to Rhythms Gonna Get You Records Database:"

  var context = new SuncoastMoviesContext();

- var userChoice=false;

- while (userChoice==false)

  - View
    - All bands
    - Band Albums
    - Album by Band
  - Current Clients
    - Signed
    - Not Signed
  - Add
    - Add album for a band
    - Add a song to album
  - Contract change
    - Let band go
    - Resign a Band
  - Quit

  - var choice = PromptForString("Choice: ").ToUpper().Trim();
  - switch (choice)

- case("View")

  - var viewOptions=Print out the options for view

  - All Bands
  - Albums By Band
  - All Album

  - Switch (viewOptions)

  - case ("All Bands")

    - foreach band in context.Bands
    - Print out either all the information or just the band name

  - case ("Albums by Band")
      <!-- - foreach Albums in context.Albums.Include(album => album.BandSelected))
              {
                  Console.WriteLine($"The band {{movie.TheRatingAssociatedToTheMovieObject.Description}");
              } -->

    - var bandName= Ask what band they are looking for
    - foreach album in context.Album.Include(band=> band.Name=="bandName").Include(album=>album.Title)
    - foreach album in context.Band.Include(band=> band.Name=="bandName")
      - Context writeline album
        **More Specific Here**

  - case ("All Albums")
    -var albumRelease= context.Album.OrderBy(date=>date.ReleaseDate)

    - foreach album in albumRelease
      - Print out album.Name

  - default ()
  - Please enter an option

- case ("Current Clients")

  - var contractStatus= Ask if they want to view Bands with signed or bands not signed"

  - Bands signed contracts
  - Bands not signed contracts

  - If (ContractStatus=="Signed")
    - var signedBands= context.Band.Where(band=>band.IsSigned=True);
    - foreach var signed in signedBands
      - Console WriteLine signed.Name
  - If (ContractsStatus=="Not signed)
    - var notSignedBands= context.Band.Where(band=>band.IsSigned=False);
    - foreach var signed in notSignedBands
      - Console WriteLine signed.Name

- case ("Add")
- var addOptions= Store which option the user picks

  - Add album for a band
  - Add a song to album

  if (addOptions=="Add album for a band")

  - var band= Ask which band you would like to add to
  - var bandPicked = context.Bands.First(band => band.Name == "band");

  - var newTitle= Ask what the new title is
  - var newIsExplicit= Ask if it is explicit (True or False)
  - var newReleaseDate= int.Parse(Ask the release Date)

  - Add new object of album
  - var newAlbum = new Album
  - {

    - Title= newTitle
    - IsExplicit=newIsExplicit
    - ReleaseDate=newReleaseDate
    - BandId = bandPicked.Id,
    - };

    context.Album.Add(newAlbum);

    context.SaveChanges();

  - if (addOptions=="Add a song to an album")

    - var album= Ask which album you would like to add to
    - var albumPicked= context.Album.First(album => album.Title == "album");

    - var newTrack= Ask what the new track number is **might want to make sure it doesnt equal an exiting track**
    - var newTitle= Ask for the new Title
    - var newDuration= double.Parse(Ask the duration)

    - Add new object of Song
    - var newSong = new Song
      - {
      - Track= newTrack
      - Title=newTitle
      - Duration=newDuration
      - AlbumId = AlbumPicked.Id,
      - };

    context.Song.Add(newSong);

    context.SaveChanges();

- case ("Change Contract")
- var contractOptions= Store which option the user picks

  - Resign a band
  - Let a band go

  - if (contractOptions=="Resign a band")

    - var bandToResign= Ask which band you want to resign
      - var resignBand= context.Band.FirstOrDefault(band=> band.Name == bandToResign)
      - if (resignBand==Null)
        - Sorry no band found
      - Else
        - resignBand.IsSigned=True

  - if (" Let a band go")
    - var bandToLetGo= Ask which band you want to let go
      - var letGoBand= context.Band.FirstOrDefault(band=> band.Name == bandToLetGo)
      - if (letGoBand==Null)
        - Sorry no band found
      - Else
        - letGoBand.IsSigned=False

- case("Quit")

  - var userChoice=True;

- Good Bye message

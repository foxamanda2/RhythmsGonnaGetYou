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

  ## Menu

  - View
    - All the bands
    - View Bands albums
    - If Band is signed
      - Signed
      - Not Signed
    - By order Of release Date
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

- var userChoice=false;

- while (userChoice==false)

  - View
    - All bands
    - Band Albums
    - Band Contract
      - Signed
      - Not Signed
    - Album by release date
  - Add
    - Add album for a band
    - Add a song to album
  - Contract change
    - Let band go
    - Resign a Band
  - Quit

  - var choice = PromptForString("Choice: ").ToUpper().Trim();
  - switch (choice)

- Case("View")
- var viewOptions=Print out the options for view

  - All Bands
  - Band Albums
  - Band Contract Status
  - Album by release date

  - Switch (viewOptions)

  - case ("All Bands")

    - foreach band in context.Bands
    - Print out either all the information or just the band name

  - case ("Band Albums")

    - var bandName= Ask the band you would like to look up
    <!-- - foreach Albums in context.Albums.Include(album => album.BandSelected))
            {
                Console.WriteLine($"The band {{movie.TheRatingAssociatedToTheMovieObject.Description}");
            } -->

  - case ("Band Contract Status")
  - var contractStatus= Ask if they want to view Bands with signed or bands without signed"

    - Create Menu

    - Bands with signed contracts
    - Bands without signed contracts
    - If (ContractStatus=="Signed")
      - Print out all bands with signed contracts
    - If (ContractsStatus=="Not signed)
      - Print out all bands without signed contracts.

  - case ("Album release date")

  - default ()
  - Please enter an option

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
    - var albumPicked= context.Bands.First(album => album.Title == "album");

    - var newTrack= Ask what the new track number is **_might want to make sure it doesnt equal an old one_**
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

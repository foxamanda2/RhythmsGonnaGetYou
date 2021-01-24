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
  - Duration (INT)->In seconds
  - AlbumId (INT)
  - AlbumSelected (Album)

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

    - var bandName= Ask what band they are looking for
    - foreach album in context.Album.Include(band=> band.Name=="bandName").Include(album=>album.Title)
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
    - var newDuration= int.Parse(Ask the duration)

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

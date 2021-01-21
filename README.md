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

#

namespace RhythmsGonnaGetYou
{
    public class BandMembers

    {
        public int Id { get; set; }
        public string Position { get; set; }

        public int BandId { get; set; }
        public Band Bands { get; set; }

        public int MusicianId { get; set; }
        public Musicians Musician { get; set; }

    }
}
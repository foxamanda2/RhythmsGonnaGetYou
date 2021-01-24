namespace RhythmsGonnaGetYou
{
    public class BandMember
    {
        public int Id { get; set; }
        public string BandMembers { get; set; }

        public int BandId { get; set; }
        public Band TheBand { get; set; }

        public int MusicianId { get; set; }
        public Musicians TheMusicians { get; set; }




    }
}
using System.Collections.Generic;

namespace RhythmsGonnaGetYou
{
    public class Musicians
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<BandMembers> BandMembers { get; set; }

    }
}
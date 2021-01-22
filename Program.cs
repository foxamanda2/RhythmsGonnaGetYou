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

            foreach (var band in context.Band)
            {
                Console.WriteLine($"There is a movie named {band.Name}");
            }
        }
    }
}

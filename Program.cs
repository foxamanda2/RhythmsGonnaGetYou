﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();

            var bandCount = context.Albums.Count();
            Console.WriteLine($"There are {bandCount} movies!");
        }
    }
}

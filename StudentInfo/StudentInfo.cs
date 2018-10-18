using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo
{
    class StudentInfo
    {
        public string Name;
        public string Hometown;
        public string FavFood;
        public string FavMovie;

        public StudentInfo(string name, string hometown, string favFood, string favMovie)
        {
            Name = name;
            Hometown = hometown;
            FavFood = favFood;
            FavMovie = favMovie;
        }
    }
}

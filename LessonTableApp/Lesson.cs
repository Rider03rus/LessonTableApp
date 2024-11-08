using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTableApp
{
    public class Lesson
    {
        private string day;
        private string time;
        private string name;
        private string audience;


        public string Day { get { return day; } set { day = value; } }
        public string Time { get { return time; } set { time = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Audience { get { return audience; } set { audience = value; } }

        public Lesson() { }
        public Lesson(string name, string day, string time, string audience)
        {
            Name = name; Day = day; Time = time; Audience = audience;
        }
    }
}
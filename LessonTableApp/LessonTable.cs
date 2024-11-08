using LessonTableApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTableApp
{
    public class LessonTable
    {
        private List<Lesson> lessons;


        public List<Lesson> Lessons { get { return lessons; } set { lessons = value; } }
        public LessonTable() { }
        public LessonTable(List<Lesson> lessons) { Lessons = Sort(lessons); }

        /*
        public List<Lesson> Sort(List<Lesson> lessons)
        {
            var sortlessons = lessons
           .OrderBy(lesson => lesson.Day)
           .ThenBy(lesson => lesson.Time)
           .ToList();


            return sortlessons;

        }
        */

  

        public List<Lesson> Sort(List<Lesson> lessons)
        {
            int n = lessons.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (CompareLesson(lessons[j], lessons[j + 1]) > 0)
                    {
                        // Обмен уроков
                        var temp = lessons[j];
                        lessons[j] = lessons[j + 1];
                        lessons[j + 1] = temp;
                    }
                }
            }

            return lessons;
        }

        // Метод для сравнения двух уроков по дню недели и времени
        public int CompareLesson(Lesson l1, Lesson l2)
        {

            TimeSpan l1time = ConvertTime(l1.Time);
            TimeSpan l2time = ConvertTime(l2.Time);

            DayOfWeek l1day = ConverteDay(l1.Day);
            DayOfWeek l2day = ConverteDay(l2.Day);


            if (l1day < l2day)
                return -1;
            else if (l1day > l2day)
                return 1;
            else // Если дни недели одинаковые, сравниваем по времени занятий
                return l1time.CompareTo(l2time);
        }

        public TimeSpan ConvertTime(string x)
        {
            TimeSpan ts = new TimeSpan(int.Parse(x.Split(':')[0]),    // hours
               int.Parse(x.Split(':')[1]),    // minutes
               0   // seconds
               );
            return ts;

        }

        public DayOfWeek ConverteDay(string x)
        {
            if (x == "пн") return DayOfWeek.Monday;
            else if (x == "вт") return DayOfWeek.Tuesday;
            else if (x == "ср") return DayOfWeek.Wednesday;
            else if (x == "чт") return DayOfWeek.Thursday;
            else if (x == "пт") return DayOfWeek.Friday;
            else return DayOfWeek.Saturday;

        }


        public List<string> ShowAll(List<Lesson> lessons)
        {
            List<string> table = new List<string>();


            foreach (Lesson l in lessons)
            {


                table.Add($"{l.Day} {l.Time} {l.Name} {l.Audience} ");

            }

            return table;

        }

        public List<string>  ShowDay(DayOfWeek day)
        {
            List<string> table = new List<string>();

            foreach (Lesson l in Lessons)
            {
                if(ConverteDay(l.Day) == day)
                    table.Add($"{l.Day} {l.Time} {l.Name} {l.Audience} "); ;

            }

            return table;


        }






    }






}


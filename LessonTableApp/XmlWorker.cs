using LessonTableApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LessonTableApp
{
    public class XmlWorker
    {
        private string path = @"C:\Users\Сергей\ALL\IAP\C#\LessonTableApp\LessonTableApp\Input\Data.xml"; 
        private string savePath = @"C:\Users\Сергей\ALL\IAP\C#\LessonTableApp\LessonTableApp\Output\Data.xml";
        private XmlSerializer formatter = new XmlSerializer(typeof(List<Lesson>));
        public XmlWorker() { }



        public List<Lesson> ReadXMl()
        {

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Lesson>? newlesson = formatter.Deserialize(fs) as List<Lesson>;
                return newlesson;
            }
        }




        public void WriteXMl(List<Lesson> lessons)
        {
            using (FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, lessons);
            }


        }








    }
}

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
        private string path = @"C:\Users\Сергей\ALL\IAP\C#\LessonTableApp\LessonTableApp\Input\Data.xml"; // Укажите путь к вашему XML файлу
        private string savePath = @"C:\Users\Сергей\ALL\IAP\C#\LessonTableApp\LessonTableApp\Output\Data.xml"; // Укажите путь для сохранения XML
        private XmlSerializer formatter = new XmlSerializer(typeof(List<Lesson>));
        public XmlWorker() { }



        public List<Lesson> ReadXMl()
        {

            // восстановление массива из файла
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Lesson>? newlesson = formatter.Deserialize(fs) as List<Lesson>;
                return newlesson;
            }
        }




        public void WriteXMl(List<Lesson> lessons)
        {
            // сохранение массива в файл
            using (FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, lessons);
            }


        }








    }
}

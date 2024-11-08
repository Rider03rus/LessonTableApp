using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LessonTableApp
{
    public partial class MainWindow : Window
    {
        private List<Lesson> Lessons;
        private XmlWorker xmlWorker = new XmlWorker();
        private LessonTable LT = new LessonTable();

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Show(DayOfWeek day)
        {

            LessonsListBox.Items.Clear();

            LT.Lessons = LT.Sort(xmlWorker.ReadXMl());

            List<string> table = LT.ShowDay(day);

      

            foreach (var t in table)
            {
                LessonsListBox.Items.Add(t);


            }
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            LessonsListBox.Items.Clear();

            LT.Lessons = LT.Sort(xmlWorker.ReadXMl());

            List<string> table = LT.ShowAll(LT.Lessons);

            foreach (var t in table)
            {
                LessonsListBox.Items.Add(t);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            var addLessonWindow = new AddLessonWindow();
            if (addLessonWindow.ShowDialog() == true)
            {
                LT.Lessons.Add(addLessonWindow.NewLesson);
                MessageBox.Show("Урок добавлен!");
                Show_Click(null, null); // Обновляем список
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            if (LessonsListBox.SelectedItem != null)
            {
                var selectedText = LessonsListBox.SelectedItem.ToString();

                string[] words = selectedText.Split(' ');

                Lesson dlesson = new Lesson(words[0], words[1], words[2], words[3]);


                if (dlesson != null)
                {
                 

                    foreach (var t in LT.Lessons)
                    {
                        if (t.Name == dlesson.Name && t.Audience == dlesson.Audience && t.Day == dlesson.Day && t.Time == dlesson.Time)
                        {
                            LT.Lessons.Remove(t);
                            break;
                        }

                    }


                    MessageBox.Show("Lesson удалён!");
         
                    Show_Click(null, null); 
                }
            }
            else
            {
                MessageBox.Show("Выберите Lesson для удаления");
            }
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            xmlWorker.WriteXMl(LT.Lessons);
            MessageBox.Show("Данные сохранены");
        }

   
           

        
        private void Pn_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Monday);
        private void Vt_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Tuesday);
        private void Sr_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Wednesday);
        private void Ch_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Thursday);
        private void Fr_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Friday);
        private void Su_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Saturday);
    }
}
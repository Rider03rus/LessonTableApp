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

            // Примерный список Lessonов для отображения
            /*
            Lessons = new List<Lesson>
            {
                new Lesson { Name = "Математика", Audience = "101", Time = new TimeSpan(10, 0, 0), Day = DayOfWeek.Monday },
                new Lesson { Name = "Физика", Audience = "102", Time = new TimeSpan(9, 0, 0), Day = DayOfWeek.Monday },
                new Lesson { Name = "Химия", Audience = "103", Time = new TimeSpan(11, 0, 0), Day = DayOfWeek.Wednesday },
                new Lesson { Name = "История", Audience = "104", Time = new TimeSpan(9, 0, 0), Day = DayOfWeek.Tuesday }
            };
            */
        }

        private void Show(DayOfWeek day)
        {

            LessonsListBox.Items.Clear();

            LT.Lessons = LT.Sort(xmlWorker.ReadXMl());

            List<string> table = LT.ShowDay(day);

            // var всеLessonи = Lessons.OrderBy(Lesson => Lesson.Day).ThenBy(Lesson => Lesson.Time);

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

           // var всеLessonи = Lessons.OrderBy(Lesson => Lesson.Day).ThenBy(Lesson => Lesson.Time);

            foreach (var t in table)
            {
                LessonsListBox.Items.Add(t);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*
            // Пример добавления нового Lessonа
            Lessons.Add(new Lesson { Name = "Новый предмет", Audience = "105", Time = new TimeSpan(12, 0, 0), Day = DayOfWeek.Friday });
            MessageBox.Show("Lesson добавлен!");
            Show_Click(null, null); // Обновляем список
            */
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (LessonsListBox.SelectedItem != null)
            {
                var selectedText = LessonsListBox.SelectedItem.ToString();
                var удаляемыйLesson = Lessons.FirstOrDefault(Lesson => $"{Lesson.Day}: {Lesson.Name} - Audience {Lesson.Audience}, Время {Lesson.Time}" == selectedText);

                if (удаляемыйLesson != null)
                {
                    Lessons.Remove(удаляемыйLesson);
                    MessageBox.Show("Lesson удалён!");
                    Show_Click(null, null); // Обновляем список
                }
            }
            else
            {
                MessageBox.Show("Выберите Lesson для удаления");
            }
            */
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (LessonsListBox.SelectedItem != null)
            {
                var selectedText = LessonsListBox.SelectedItem.ToString();
                var редактируемыйLesson = Lessons.FirstOrDefault(Lesson => $"{Lesson.Day}: {Lesson.Name} - Audience {Lesson.Audience}, Время {Lesson.Time}" == selectedText);

                if (редактируемыйLesson != null)
                {
                    редактируемыйLesson.Name = "Изменённое Name"; // Пример изменения
                    MessageBox.Show("Lesson изменён!");
                    Show_Click(null, null); // Обновляем список
                }
            }
            else
            {
                MessageBox.Show("Выберите Lesson для изменения");
            }
            */
        }

        // Обработчики для кнопок с днями недели
        private void Pn_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Monday);
        private void Vt_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Tuesday);
        private void Sr_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Wednesday);
        private void Ch_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Thursday);
        private void Fr_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Friday);
        private void Su_Click(object sender, RoutedEventArgs e) => Show(DayOfWeek.Saturday);
    }
}
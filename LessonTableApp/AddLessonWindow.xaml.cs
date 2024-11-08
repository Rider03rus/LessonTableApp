using System;
using System.Windows;
using System.Windows.Controls;

namespace LessonTableApp
{
    public partial class AddLessonWindow : Window
    {
        public Lesson NewLesson { get; private set; }

        public AddLessonWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = NameTextBox.Text;
                var audience = AudienceTextBox.Text;
                var time = TimeTextBox.Text;
                var day = (DayComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                NewLesson = new Lesson(day, time, name, audience); 
                
              
                

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных: " + ex.Message);
            }
        }

        private void TimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using Newtonsoft.Json;

namespace praktikal2
{
    public partial class MainWindow : Window
    {
        private List<Notes> notes = new List<Notes>();

        public MainWindow()
        {
            InitializeComponent();
            notes = MyConverter.MyDeserialize<List<Notes>>() ?? new List<Notes>();
            listbox1.DisplayMemberPath = "note";

            UpdateNotesList();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Добавление новой заметки
            var selectedDate = datepicker.SelectedDate;
           
            if (selectedDate == null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }

            var noteDate = selectedDate.Value;
            var note = new Notes
            {
                day = noteDate.ToString("dd.MM.yyyy"),
                note = textbox1.Text,
                discription = textbox2.Text
            };

            notes.Add(note);
            MyConverter.MySerealize(notes);
            UpdateNotesList(); // обновляем список заметок
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Удаление выбранной заметки
            if (listbox1.SelectedItem != null)
            {
                var selectedNote = (Notes)listbox1.SelectedItem;
                notes.Remove(selectedNote);
                MyConverter.MySerealize(notes);

                listbox1.ItemsSource = null; // очищаем список
                UpdateNotesList(); // обновляем список заметок
            }
        }



        

        private void UpdateNotesList()
        {
            // Обновление списка заметок в ListBox
            var selectedDate = datepicker.SelectedDate;
            if (selectedDate != null)
            {
                var selectedDateString = selectedDate.Value.ToString("dd.MM.yyyy");
                var selectedNotes = notes.Where(n => n.day == selectedDateString).ToList();
                listbox1.ItemsSource = selectedNotes;
               
            }
            else
            {
                listbox1.ItemsSource = null;
            }
        }

        private void listbox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedNote = (Notes)listbox1.SelectedItem;
            if (selectedNote != null) // добавляем проверку
            {
                textbox1.Text = selectedNote.note;
                textbox2.Text = selectedNote.discription;
            }
            UpdateNotesList();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Изменение выбранной заметки
            if (listbox1.SelectedItem != null)
            {
                var selectedNote = (Notes)listbox1.SelectedItem;
                selectedNote.note = textbox1.Text;
                selectedNote.discription = textbox2.Text;
                MyConverter.MySerealize(notes);

                UpdateNotesList();
            }
        }

        private void datepicker_SelectedDateChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            
            
                UpdateNotesList();
           
        }
    }
}
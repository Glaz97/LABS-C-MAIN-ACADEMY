using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calculator
{

    public partial class StudentList : Window
    {
        ObservableCollection<Student> TableDataGridStudents = new ObservableCollection<Student>();

        public class Student
        {
            public string Name { get; set; }
            public double Rate { get; set; }

            public Student(string name, double rate)
            {
                Name = name;
                Rate = rate;
            }

            public Student()
            {

            }

            public static ObservableCollection<Student> GetStudents()
            {
                ObservableCollection<Student> result = new ObservableCollection<Student>
            {
                new Student() { Name = "Andy Houp", Rate = 70 },
                new Student() { Name = "Mary First", Rate = 64 },
                new Student() { Name = "John Miller", Rate = 30 },
                new Student() { Name = "Helen Best", Rate = 0 },
                new Student() { Name = "Ivan Stown", Rate = 29 },
                new Student() { Name = "Mishel Capoa", Rate = 91 }
            };
                return result;
            }
        }

        public StudentList()
        {
            InitializeComponent();
        }

        private void StudentListGrid_Initialized(object sender, EventArgs e)
        {
            TableDataGridStudents = Student.GetStudents();
            StudentListGrid.ItemsSource = TableDataGridStudents;           
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            TableDataGridStudents.Remove((Student)StudentListGrid.CurrentItem);
            StudentListGrid.ItemsSource = null;
            StudentListGrid.ItemsSource = TableDataGridStudents;
        }

        private void ClearList_Click(object sender, RoutedEventArgs e)
        {
            StudentListGrid.ItemsSource = null;
        }

        private void GetBaseList_Click(object sender, RoutedEventArgs e)
        {
            TableDataGridStudents.Remove((Student)StudentListGrid.CurrentItem);
            StudentListGrid.ItemsSource = TableDataGridStudents;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Student
    {
        public string name;
        public double grade;
        public Student()
        { }

        public Student(string n, double g)
        {
            this.name = n;
            this.grade = g;
        }

        public override string ToString()
        {

            return this.name;
        }
    }

    public partial class MainWindow : Window
    {
        List<Student> studentsList;
        public MainWindow()
        {
            this.studentsList = new List<Student>();

            InitializeComponent();

            this.studentNamesListbox.ItemsSource = studentsList;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string studentName = this.nameTxtbox.Text;
            double grade = Convert.ToDouble(this.gradeTxtbox.Text);

            Student newStu = new Student(studentName, grade);
            studentsList.Add(newStu);

            this.studentNamesListbox.Items.Refresh();
            //MessageBox.Show("OK");
        }

        private void studentNamesListbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.studentNamesListbox.SelectedIndex != -1)
            {
                Student selStu = (Student)this.studentNamesListbox.SelectedItem;
                MessageBox.Show(selStu.grade.ToString());

            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string nameSearch = this.inputNameTxtbox.Text.ToLower();
            bool nameFalse = false;

            for (int x = 0; x < this.studentsList.Count; x++)
            {

                if (studentsList[x].name.ToLower() == nameSearch)
                {
                    //show student name in the list 
                    double grade = this.studentsList[x].grade;
                    string message = this.studentsList[x].name + "" + this.studentsList[x].grade.ToString("F2");
                    nameFalse = true;
                    ShowStudentSeacrch.Text = message;
                    break;
                }

            }

            if (nameFalse == false)
            {
                ShowStudentSeacrch.Text = "no student of that name";
            }


        }
    }
}
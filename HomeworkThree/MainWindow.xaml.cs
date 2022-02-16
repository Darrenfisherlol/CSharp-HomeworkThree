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
    public class Fruit
    {
        public string name;
        public double cost;
        public Fruit()
        { }

        public Fruit(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

        //public override string ToString()
        //{

        //    return this.name;
        //}
    }

    public partial class MainWindow : Window
    {
        List<Fruit> fruitList;
        public MainWindow()
        {
            this.fruitList = new List<Fruit>();

            // created each fruit to be displayed
            Fruit fruitOne = new Fruit("Apples", .99);
            Fruit fruitTwo = new Fruit("Oranges", .5);
            Fruit fruitThree = new Fruit("Bananas", .5);
            Fruit fruitFour = new Fruit("Grapes", 2.99);
            Fruit fruitFive = new Fruit("Blueberries", 1.99);

            // add fruit to list
            fruitList.Add(fruitOne);
            fruitList.Add(fruitTwo);
            fruitList.Add(fruitThree);
            fruitList.Add(fruitFour);
            fruitList.Add(fruitFive);

            InitializeComponent();

            this.fruitNameListBox.ItemsSource = fruitList;
        }


        private void fruitName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.fruitNameListBox.SelectedIndex != -1)
            {
                Fruit selStu = (Fruit)this.fruitNameListBox.SelectedItem;
                ShowfruitNameTxtbox.Text = selStu.name + ": " + selStu.cost.ToString("C2");

            }
        }

        private void showPriceBtn(object sender, RoutedEventArgs e)
        {
            string nameSearch = this.fruitNameTxtbox.Text.ToLower();
            bool nameFalse = false;

            for (int x = 0; x < this.fruitList.Count; x++)
            {

                if (fruitList[x].name.ToLower() == nameSearch)
                {
                    //show student name in the list 
                    string message = this.fruitList[x].name + ": " + this.fruitList[x].cost.ToString("C2");
                    
                    nameFalse = true;

                    ShowfruitNameTxtbox.Text = message;
                    break;
                }

            }

            if (nameFalse == false)
            {
                ShowfruitNameTxtbox.Text = "no fruit of that name";
            }


        }
    }
}
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

namespace taskTwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Receipt
        {
            public int CustomerID;
            public int CogQuantity;
            public int GearQuantity;
            public DateTime SaleDate;


            public double CogPrice = 79.99;
            public double GearPrice = 250;
            public double SalesTaxPercent = .089;

            // null constructor
            public Receipt()
            {

            }

            // main constructor
            public Receipt(int customerID, int numCogs, int numGears)
            {
                CustomerID = customerID;
                CogQuantity = numCogs;
                GearQuantity = numGears;
                SaleDate = DateTime.Now;

            }



        }



        public MainWindow()
        {



            InitializeComponent();



        }





    }
}

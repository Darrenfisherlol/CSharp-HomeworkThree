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
    // class for the receipt object
    class Receipt
    {
        // initialized the needed variables
        public int CustomerID;
        public int CogQuantity;
        public int GearQuantity;
        public DateTime SaleDate;

        public double CogPrice = 79.99;
        public double GearPrice = 250;
        public double SalesTaxPercent = .089;

        public double subTotal;
        public double tax;
        public double total;

        public Receipt()
        {

        }

        public Receipt(int customerID, int numCogs, int numGears)
        {
            CustomerID = customerID;
            CogQuantity = numCogs;
            GearQuantity = numGears;
            SaleDate = DateTime.Now;

        }

        // calculates totals of each cost
        public void calcTotals()
        {
            subTotal = CogPrice * CogQuantity + GearPrice * GearQuantity;
            tax = subTotal * SalesTaxPercent;
            total = subTotal + tax;
        }

        // calls calc totals when needed and returns a string reciept
        public string getReceipt()
        {
            calcTotals();
            string message = ("Customer ID: " + CustomerID + "\n $ of Cogs: " + CogQuantity + "\n # of Gears: " + GearQuantity + "\n Subtotal: " + subTotal.ToString("C2") + "\n Tax: " + tax.ToString("C2") + "\n Total: " + total.ToString("C2"));
            return message;
        }






        // keeps the display list in horizontal proper order
        public override string ToString()
        {
            return ("Customer: " + CustomerID + " " + SaleDate);

        }





    }
    public partial class MainWindow : Window
    {
        // list to be accessed anywhere in this class; containing receipt information for all inputs
        List<Receipt> receiptList;

        public MainWindow()
        {
            this.receiptList = new List<Receipt>();

            InitializeComponent();

            // attach the listbox to a list to be displayed
            
            this.allOrdersListBox.ItemsSource = receiptList;

        }

        private void addButtonClicked(object sender, RoutedEventArgs e)
        {
            // user input to add to list
            int idNum = Convert.ToInt32(customerInput.Text);
            int cogsNum = Convert.ToInt32(cogsInput.Text);
            int gearsNum = Convert.ToInt32(gearsInput.Text);

            Receipt newReceipt;

            // placed the new object receipt into a list & created it
            receiptList.Add(newReceipt = new Receipt(idNum, cogsNum, gearsNum));

            // show the new receipts on each list box
            receiptTextBox.Text = newReceipt.getReceipt();

            /*
             *Prints name verticaly
             */


            // to.String override to print the needed output instead of the list name
            allOrdersListBox.ItemsSource = receiptList.ToString();
            



            // need to refresh everytime to make new entries popup
            allOrdersListBox.Items.Refresh();
        }

        private void mouseClickShowReceipt(object sender, MouseButtonEventArgs e)
        {
            // get the index clicked on and display it in the receipt text box
            if (this.allOrdersListBox.SelectedIndex != -1)
            {
                Receipt receipt = (Receipt)this.allOrdersListBox.SelectedItem;
                receiptTextBox.Text = receipt.getReceipt();
            }
            
        }

    }
}

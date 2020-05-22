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

namespace BankApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> accounts;
        public MainWindow()
        {
            InitializeComponent();
            // called to create data initially
            //utilities.createData();

            accounts = utilities.readData();
            



        }

        private void UserBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
            userError.Content = userBox.Text.Length < 5 ? "Too short": null;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordError.Content = passwordBox.Text.Length < 5 ? "Too short" : null;
        }

        private void IbanBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ibanError.Content = ibanBox.Text.Length < 10 ? "Too short" : null;
        }

        private void GetAccBtn_Click(object sender, RoutedEventArgs e)
        {

            //search for errors
            List<Account> matches = accounts.Where(akount => akount.userName == userBox.Text).ToList();
            try
            {
                matches.First();
            }
            catch
            {
                userError.Content += $"{Environment.NewLine} no such user";
            }
            if (matches.Any())
            {
                matches = matches.Where(akount => akount.password == passwordBox.Text).ToList();

                try
                {
                    matches.First();
                }
                catch
                {
                    passwordError.Content += $"{Environment.NewLine} wrong password";
                    
                }

                if (matches.Count > 0)
                {
                    matches = matches.Where(akount => akount.IBAN == ibanBox.Text).ToList();
                    try
                    {
                        matches.First();

                    }
                    catch
                    {
                        ibanError.Content += $"{Environment.NewLine} That user does not have that IBAN";
                    }
                }

           
            }

            try
            {
                //update the data
                detailBox.Content = matches.First().toString();
                matches.First().lastVisited = DateTime.Now;
                utilities.storeData(accounts);
            }
            catch
            {
                detailBox.Content = "Nothing found, check the errors!";
            }





        }
    }
}

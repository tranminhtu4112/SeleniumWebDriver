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
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using OpenQA.Selenium;

namespace SeleniumTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountList accountList = new AccountList(); // Khởi tạo giá trị biên
            int timeSleep = 1000;
            StreamWriter myfile = File.CreateText("C:/Users/ASUS/Desktop/ResultTestSelenium.txt"); // tạo file để kiêm tra lại

            try
            {
                ChromeDriver chromeDriver = new ChromeDriver(); // Khởi động trình duyệt
                
                foreach (var account in accountList.accounts)
                {
                    Thread.Sleep(timeSleep);
                    chromeDriver.Url = "https://localhost:44352/Login/Index"; // Truy cập đến website cần test
                    var email = chromeDriver.FindElementById("email");       // Lấy thuộc tính thẻ input theo id của email
                    var pass = chromeDriver.FindElementById("password");    // Lấy thuộc tính thẻ input theo id của password
                    var submit = chromeDriver.FindElementById("submit");   // Lấy thuộc tính thẻ button submit theo id  
                    Thread.Sleep(timeSleep);
                    email.SendKeys(account.email);                       // Gán giá trị email
                    Thread.Sleep(timeSleep);
                    pass.SendKeys(account.password);                   // Gán giá trị password
                    Thread.Sleep(timeSleep);                          // Click để login
                    submit.Click();

                    try
                    {
                        String rs = chromeDriver.FindElement(By.Id("alertDanger")).GetAttribute("value"); // Lấy giá trị alert login
                        if (rs == "success")
                            { 
                                myfile.WriteLine("Email: " + account.email);
                                myfile.WriteLine("Password: " + account.password);
                                myfile.WriteLine("Status: Login success");
                                myfile.WriteLine(" ");
                            }
                        else if(rs == "failed")
                            {
                                myfile.WriteLine("Email: " + account.email);
                                myfile.WriteLine("Password: " + account.password);
                                myfile.WriteLine("Status: Login failed");
                                myfile.WriteLine(" ");
                            }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            catch(Exception exc)
            {
                exc.ToString();
            }
            finally
            {
                myfile.Close();
            }
        }
    }
}

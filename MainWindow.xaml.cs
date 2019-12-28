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
using Microsoft.Win32;
using mshtml;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Reflection;


namespace papersearch
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> urlist = new List<string>();
        StringBuilder mybuilder = new StringBuilder();


        public MainWindow()
        {

            InitializeComponent();
           
        }


        private void opentable()
        {
        }

        private void Navigate(WebBrowser mybrowser, String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                mybrowser.Navigate(new Uri(address));
                
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        string ad = "";
        private void ReadArtical()
        {

            

        }

        private void Treebrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
           
        }

        public void SuppressScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;

            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;

            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }

        private void tb2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void readbook()
        {
           
        }

        private void Treebrowser_LoadCompleted1(object sender, NavigationEventArgs e)
        {
           
        }

        private delegate void UpdateUIDelegate();

        int counter = 0;

        private void ThreadUpdateUI()
        {
            
        }

        bool change = true;

        public void changeitem()
        {

        }



        private void IEbrowserFix()
        {
            try
            {
                Microsoft.Win32.RegistryKey regDM = default(Microsoft.Win32.RegistryKey);
                bool is64 = Environment.Is64BitOperatingSystem;
                string KeyPath = "";
                if (is64)
                {
                    KeyPath = "SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                }
                else
                {
                    KeyPath = "SOFTWARE\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                }

                regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, false);
                if (regDM == null)
                {
                    regDM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath);
                }

                object Sleutel = null;
                if ((regDM != null))
                {
                    string location = System.Environment.GetCommandLineArgs()[0];
                    string appName = System.IO.Path.GetFileName(location);

                    Sleutel = regDM.GetValue(appName);
                    if (Sleutel == null)
                    {
                        //Sleutel onbekend
                        regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, true);
                        Sleutel = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

                        //What OS are we using
                        Version OsVersion = System.Environment.OSVersion.Version;

                        if (OsVersion.Major == 6 & OsVersion.Minor == 1)
                        {

                            //WIN 7
                            ((RegistryKey)Sleutel).SetValue(appName, 10000, Microsoft.Win32.RegistryValueKind.DWord);
                        }
                        else if (OsVersion.Major == 6 & OsVersion.Minor == 2)
                        {
                            //WIN 8
                            ((RegistryKey)Sleutel).SetValue(appName, 10000, Microsoft.Win32.RegistryValueKind.DWord);
                        }
                        else if (OsVersion.Major == 5 & OsVersion.Minor == 1)
                        {
                            //WIN xp
                            ((RegistryKey)Sleutel).SetValue(appName, 10000, Microsoft.Win32.RegistryValueKind.DWord);
                        }

                        ((RegistryKey)Sleutel).Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string GB2312ToUTF8(string str)
        {
            try
            {
                Encoding gb2312 = Encoding.GetEncoding(1200);
                Encoding uft8 = Encoding.GetEncoding("gb2312");
                byte[] temp = gb2312.GetBytes(str);
                MessageBox.Show("gb2312的编码的字节个数：" + temp.Length);
                for (int i = 0; i < temp.Length; i++)
                {
                    //   MessageBox.Show(Convert.ToUInt16(temp[i]).ToString());
                }
                byte[] temp1 = Encoding.Convert(gb2312, uft8, temp);
                MessageBox.Show("uft8的编码的字节个数：" + temp1.Length);
                for (int i = 0; i < temp1.Length; i++)
                {
                    //  MessageBox.Show(Convert.ToUInt16(temp1[i]).ToString());
                }
                string result = uft8.GetString(temp1);
                return result;
            }
            catch (Exception ex)//(UnsupportedEncodingException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            string result = textbox1.ToString();
            Navigate(mainbrowser, "https://www.researchgate.net/search?q="+result.Replace(" ","+"));
            /*
            string temp = textbox1.Text;
            int start = result.IndexOf(temp);
            change = false;
            while (start > 0)
            {
                textbox1.Text += result.Substring(start, start + 100 > result.Length ? result.Length - start - 1 : 100) + "\r\n";
                textbox1.Text += "----------------------------" + "\r\n";
                start = result.IndexOf(temp, start + 1);
            }
            */


        }

        private void tb2_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
        }

        // private void textbox1_MouseEnter(object sender, keyd e)
        // {
        //     textbox1.Text = "";
        // }

        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            string content = textbox1_Copy.Text;
            int begin=content.IndexOf("DOI:");
            if(begin>=0)
            {
                content = content.Substring(begin+5);
            }

            int end = content.IndexOf("ISBN:");
            if (end > 0)
            {
                content = content.Substring(0,content.Length- end);
            }

            Navigate(treebrowser, "https://www.sci-hub.tw/" + content);
            textbox2.Text = "https://www.sci-hub.tw/" + content;
            tc1.SelectedIndex = 1;

        }
    }




}
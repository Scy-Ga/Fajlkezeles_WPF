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
using System.IO;
using Microsoft.Win32;

namespace Forma
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

        private void ButtonBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            if (opf.ShowDialog() == true)
            {
                //txbpath.Text = opf.FileName;
                string[] cim = opf.FileName.Split('\\');

                txbpath.Text = (Directory.GetDirectoryRoot(opf.FileName) + @"..\..\" + cim.Last<string>()).ToString();

                List<string> ki = new List<string>();
                ki.Add(cim.Last<string>());

                File.WriteAllLines("FileName.txt", ki,Encoding.Default);

                long meret = new FileInfo(opf.FileName).Length;
                txbGetPath.Text = meret.ToString() + " bite";

                
                    

                #region Kezdetek
                //StreamReader sr = new StreamReader("opftextpath.txt",Encoding.Default);

                //    string[] db = sr.ReadLine().Split('\\');

                //        string b = db.Last<string>();

                //List<string> Lb = new List<string>();
                //    Lb.Add(b);



                //    File.WriteAllLines("b.txt", Lb);
                //sr.Close();

                //StreamReader bsor = new StreamReader("b.txt",Encoding.Default);
                //string[] bindex = bsor.ReadLine().Split('.');
                //txbMSH.Text = bindex[0].ToString();
                //bsor.Close();
                #endregion
            }


        }

        private void buttonGet_Click(object sender, RoutedEventArgs e)
        {
            StreamReader bsor = new StreamReader("FileName.txt", Encoding.Default);
            string[] bindex = bsor.ReadLine().Split('.');
            string bindexnull = bindex[0];
            //txbMSH.Text = bindex[0].ToString();
            bsor.Close();

            List<string> beolvasottcim = new List<string>(File.ReadLines("FileName.txt",Encoding.Default));
            string teljescim = "";
            for (int l = 0; l < beolvasottcim.Count; l++)
            {
                 teljescim += beolvasottcim[l];
            }




            //long meret = new FileInfo(txbpath.Text).Length;
            //txbGetPath.Text = meret.ToString() + " bite";



            //char[] MGH = {'a','A', 'á', 'Á', 'e', 'E', 'é', 'É', 'i', 'I', 'í', 'Í', 'o', 'O','ó','Ó','ö','Ö','ő','Ő','u','U','ú','Ú','ü','Ü','ű','Ű'};
            //string MGHOut = "";


            char[] MSH = {'b', 'B', 'c', 'C', 'd', 'D', 'f', 'F', 'g', 'G', 'h', 'H', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'p', 'P', 'q', 'Q',
            'r', 'R','s', 'S','t', 'T','x', 'X','y', 'Y','z', 'Z','v','V','w','W'};

            string MSHOut = "";
                string karakter = "";



            if (bindex.Length > 2)
            {

                

                for (int i = 0; i < bindex.Length - 1; i++)
                {
                    //txbNev.Text += bindex[i] + ".";
                    karakter += bindex[i];
                }

                for (int i = 0; i < karakter.Length; i++)
                {
                    for (int f = 0; f < MSH.Length; f++)
                    {
                        if (MSH[f] == karakter[i])
                        {
                            MSHOut += MSH[f];
                        }
                        
                    }


                }

                string nincs = "Nincs benne MSH!";
                if (MSHOut == "")
                {
                    txbMSH.Text = nincs.ToString();
                }
                else
                {
                    txbMSH.Text = MSHOut.ToString();

                }

                txbNev.Text = teljescim.Substring(0, teljescim.Length - bindex.Last<string>().Length) + bindex.Last<string>();

                txbKiterjesztes.Text = "." + bindex.Last<string>();
            }
            else
            {
                for (int i = 0; i < bindexnull.Length; i++)
                {
                    //MSHOut += bindex[0][i];

                    for (int j = 0; j < MSH.Length; j++)
                    {
                        if (MSH[j] == bindexnull[i])
                        {
                            MSHOut += MSH[j];
                        }
                        

                    }
                }





                string nincs = "Nincs benne MSH!";
                if (MSHOut == "")
                {
                    txbMSH.Text = nincs.ToString();
                }
                else
                {
                    txbMSH.Text = MSHOut.ToString();

                }







                txbNev.Text = bindex[0] + "." + bindex[1];

                txbKiterjesztes.Text ="." +  bindex[1];

            }






            

            
            

            //"." + bindex.Last<string>();
        }
    }
}

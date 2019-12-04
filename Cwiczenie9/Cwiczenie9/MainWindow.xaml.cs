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

namespace Cwiczenie9
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        string imie;
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            imie = MyTextBoxPobieranie.Text;
            if (MyTextBoxPobieranie.Text == "[wprowadz imie]")
                MyTextBoxWyswietlanie.Text = "Du bist debilen!";
            else
                MyTextBoxWyswietlanie.Text = "Witaj, Bot " + imie;
        }

        private void ButtonCzyszczenie_Click(object sender, RoutedEventArgs e)
        {
            MyTextBoxWyswietlanie.Text = " ";
        }
    }
}

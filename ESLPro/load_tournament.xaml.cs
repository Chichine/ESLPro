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
using System.Windows.Shapes;

namespace ESLPro
{
    /// <summary>
    /// Logique d'interaction pour load_tournament.xaml
    /// </summary>
    public partial class load_tournament : Window
    {
        public load_tournament()
        {
            InitializeComponent();

            DataScript Script = new DataScript();

            List<string> AllTourneys = Script.getAllTournaments();

            foreach(string tourn in AllTourneys)
            {
                ListBoxItem newBox = new ListBoxItem();

                newBox.Content = tourn;

                TournoisList.Items.Add(newBox);
            }
        }

        public void retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();

            page.Show();
            this.Close();
        }
    }
}

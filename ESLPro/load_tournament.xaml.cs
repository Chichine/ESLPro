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

            Dictionary<int, string> AllTourneys = Script.getAllTournaments();

            foreach(var tourn in AllTourneys)
            {
                ListBoxItem newBox = new ListBoxItem();

                newBox.Content = tourn.Value;
                newBox.Name = "Id_" + tourn.Key.ToString();

                newBox.AddHandler(ListBoxItem.MouseDownEvent, new MouseButtonEventHandler(Load_Tourney), true);

                TournoisList.Items.Add(newBox);
            }
        }

        public void Load_Tourney(object sender, RoutedEventArgs e) // Load Tourney
        {
            ListBoxItem tsender = (ListBoxItem)sender;

            int Id = Convert.ToInt32(tsender.Name.Substring(3));
            //Console.WriteLine(Id);

            DataScript Script = new DataScript();
            List<string> Tourney = Script.GetTournament(Id);

            //Console.WriteLine(Tourney[1]);

            Properties.Settings.Default.currentTournament = Tourney[1];
            Properties.Settings.Default.currentTournamentId = Convert.ToInt32(Tourney[0]);
            tournament_teams page = new tournament_teams();
            page.Show();
            this.Close();
        }

        public void retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();

            page.Show();
            this.Close();
        }


    }
}

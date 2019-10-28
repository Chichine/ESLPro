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
    /// Logique d'interaction pour teams_settings.xaml
    /// </summary>
    public partial class teams_settings : Window
    {
        public static class Globals
        {
            public static int TeamId = Properties.Settings.Default.currentTeamId;
            public static string TeamName = "";
        }

        public teams_settings()
        {
            InitializeComponent();

            DataScript Script = new DataScript();

            List<string> team = Script.GetTeam(Globals.TeamId);
            NomTournoi.Text = "Equipe: " + team[1];
        }

        private void Ajout_Joueur(object sender, RoutedEventArgs e)
        {
            string TPseudo = Pseudo.Text;
            string TNom = Nom.Text;
            string TPrenom = Prenom.Text;

            DataScript Script = new DataScript();
            int Id = Script.newJoueur(Globals.TeamId, TNom, TPrenom, TPseudo);

            ListBoxItem newBox = new ListBoxItem();
            newBox.Content = TPseudo;
            newBox.Name = "Id_" + Id;

            JoueursList.Items.Add(newBox);
        }
    }
}

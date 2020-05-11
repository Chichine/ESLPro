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
    /// Logique d'interaction pour joueur_settings.xaml
    /// </summary>
    public partial class joueur_settings : Window
    {
        public static class Globals
        {
            public static int JoueurId = Properties.Settings.Default.currentPlayerId;
        }
        public joueur_settings()
        {
            InitializeComponent();
            Globals.JoueurId = Properties.Settings.Default.currentPlayerId;
            DataScript Script = new DataScript();

            List<string> Joueur = Script.GetJoueur(Globals.JoueurId);

            NomJoueur.Text = "Joueur: " + Joueur[3];


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataScript Script = new DataScript();
            Script.DeleteJoueur(Globals.JoueurId);

            teams_settings page = new teams_settings();
            page.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            teams_settings page = new teams_settings();
            page.Show();
            this.Close();
        }
    }
}

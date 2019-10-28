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

        public void UpdateNombre() {
            DataScript Script = new DataScript();
            int nombreJoueur = Script.GetNombreJoueursDansEquipe(Globals.TeamId);
            NombreJoueur.Text = "Joueurs: " + nombreJoueur.ToString() + "/5";
        }

        public teams_settings()
        {
            InitializeComponent();

            DataScript Script = new DataScript();

            List<string> team = Script.GetTeam(Globals.TeamId);
            NomTournoi.Text = "Equipe: " + team[1];

            Dictionary<int, string> joueurs = Script.GetJoueurs(Globals.TeamId);

            foreach(var joueur in joueurs)
            {
                int Id = joueur.Key;
                string TPseudo = joueur.Value;

                ListBoxItem newBox = new ListBoxItem();
                newBox.Content = TPseudo;
                newBox.Name = "Id_" + Id;

                newBox.AddHandler(ListBoxItem.MouseDownEvent, new MouseButtonEventHandler(Load_Joueur), true);

                JoueursList.Items.Add(newBox);
            }

            UpdateNombre();
        }

        private void Ajout_Joueur(object sender, RoutedEventArgs e)
        {
            string TPseudo = Pseudo.Text;
            string TNom = Nom.Text;
            string TPrenom = Prenom.Text;

            DataScript Script = new DataScript();

            int nombreJoueurs = Script.getNombreJoueursAvecPseudo(TPseudo, Globals.TeamId);
            if(nombreJoueurs == 0)
            {
                int nombreJoueur = Script.GetNombreJoueursDansEquipe(Globals.TeamId);
                if (nombreJoueur < 5)
                {
                    int Id = Script.newJoueur(Globals.TeamId, TNom, TPrenom, TPseudo);

                    ListBoxItem newBox = new ListBoxItem();
                    newBox.Content = TPseudo;
                    newBox.Name = "Id_" + Id;

                    newBox.AddHandler(ListBoxItem.MouseDownEvent, new MouseButtonEventHandler(Load_Joueur), true);

                    JoueursList.Items.Add(newBox);
                    UpdateNombre();
                } else
                {
                    MessageBox.Show("Il y a déjà 5 joueurs dans cette équipe!");
                }
            } 
            else
            {
                MessageBox.Show("Ce joueur est déjà dans cette équipe");
            }
        }

        public void Load_Joueur(object sender, RoutedEventArgs e) // Load Tourney
        {
            ListBoxItem tsender = (ListBoxItem)sender;

            int JoueurId = Convert.ToInt32(tsender.Name.Substring(3));

            Properties.Settings.Default.currentPlayerId = JoueurId;

            joueur_settings page = new joueur_settings();
            page.Show();
            this.Close();
        }
    }
}

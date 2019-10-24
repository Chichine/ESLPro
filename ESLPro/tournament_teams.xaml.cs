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
using Spire.Pdf;

namespace ESLPro
{
    /// <summary>
    /// Logique d'interaction pour tournament_teams.xaml
    /// </summary>
    public partial class tournament_teams : Window
    {

        public static class Globals
        {
            public static int currentId = Properties.Settings.Default.currentTournamentId;
            public static int NombreEquipeMax = 0;
        }
        
        public void UpdateNombreEquipe()
        {
            DataScript Script = new DataScript();
            int nombreEquipes = Script.GetNombreEquipesDansTournoi(Globals.currentId);
            teamMax.Text = "Equipes: " + nombreEquipes + "/" + Globals.NombreEquipeMax;
        }
        
        public tournament_teams()
        {
            InitializeComponent();

            WindowTitle.Text = "Tournoi: " + Properties.Settings.Default.currentTournament; // Valeur globale
            Console.WriteLine(Globals.currentId);

            DataScript Script = new DataScript();

            List<string> Tourney = Script.GetTournament(Globals.currentId);
            Globals.NombreEquipeMax = Convert.ToInt32(Tourney[3]);
            Dictionary<int, string> Teams = Script.getTeamsFromTournament(Globals.currentId);

            Console.WriteLine(Teams.Count());

            foreach(var team in Teams)
            {
                ListBoxItem newBox = new ListBoxItem();
                newBox.Content = team.Value;
                newBox.Name = "Id_" + team.Key;

                AllTeams.Items.Add(newBox);
            }

            UpdateNombreEquipe();
        }

        public void test_Click(object sender, RoutedEventArgs e)
        {
            PDF pdfmodule = new PDF();

            DataScript test = new DataScript();

            PdfDocument doc = pdfmodule.CreateDoc();
            PdfPageBase page1 = pdfmodule.CreatePage(doc);

            pdfmodule.newTitle(page1, "Tournoi: " + Properties.Settings.Default.currentTournament, 100, 0);
         
            pdfmodule.SaveAndOpen(doc);
        }

        private void TeamAdd_Click(object sender, RoutedEventArgs e)
        {
            string Nom = teamBox.Text;

            DataScript Script = new DataScript();
            

            if(Nom != "")
            {
                int nombreEquipe = Script.getNombreEquipeAvecNom(Nom, Globals.currentId);
                if (nombreEquipe == 0)
                {
                    int nombreEquipeTotal = Script.GetNombreEquipesDansTournoi(Globals.currentId);
                    if (nombreEquipeTotal < Globals.NombreEquipeMax)
                    {
                        int Id = Script.newTeam(Nom, Globals.currentId);

                        ListBoxItem newBox = new ListBoxItem();
                        newBox.Content = Nom;
                        newBox.Name = "Id_" + Id;

                        AllTeams.Items.Add(newBox);
                        UpdateNombreEquipe();
                    }
                    else
                    {
                        MessageBox.Show("Erreur: Nombre d'équipe maximum atteint");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur: Cette équipe est déjà inscrite");
                }
            }
            else
            {
                MessageBox.Show("Erreur: Vous n'avez pas entré de nom d'équipe");
            }
        }
    }
}

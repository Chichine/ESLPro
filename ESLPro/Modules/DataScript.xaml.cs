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
using System.Data.SqlClient;

namespace ESLPro
{
    /// <summary>
    /// Logique d'interaction pour DataScript.xaml
    /// </summary>
    public partial class DataScript : Window
    {
        public DataScript()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static string cn_String = Properties.Settings.Default.connection_String;
        }

        public List<string> GetTournament(int Id)
        {
            List<string> tourney = new List<string>();

            SqlConnection cn = new SqlConnection(Globals.cn_String);
            
            string queryString = "SELECT * FROM tournois WHERE Id=" + Id.ToString();

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                for (int i = 0; i < 4; i++)
                {
                    tourney.Add(reader[i].ToString());
                }
            }

            return tourney;
        }

        public void DataGet() // Was Test
        {
            SqlConnection cn = new SqlConnection(Globals.cn_String);

            string queryString = "SELECT * FROM tournois";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}",
                    reader[0], reader[1]));
            }
        }

        public int DataNew(string Name, string BO, int numTeam)
        {
            SqlConnection cn = new SqlConnection(Globals.cn_String);

            
            string queryString = "INSERT INTO tournois (Nom, BO, numTeam) VALUES('" + Name + "', '"+BO+"', +"+ numTeam +")";
            string queryString2 = "SELECT MAX(Id) FROM tournois";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand(queryString2, cn);
            SqlDataReader reader = command2.ExecuteReader();

            reader.Read();
            int lastId = Convert.ToInt32(reader[0]);
            
            return lastId;
        }

        public Dictionary<int, string> getTeamsFromTournament(int IdTournoi)
        {
            Dictionary<int, string> Teams = new Dictionary<int, string>();

            SqlConnection cn = new SqlConnection(Globals.cn_String);

            string QueryString = "SELECT * FROM equipes WHERE idTournoi=" + IdTournoi;
            Console.WriteLine(QueryString);
            
            SqlCommand command = new SqlCommand(QueryString, cn);

            cn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teams.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }

            return Teams;
        }

        public int newTeam(string Name, int IdTournoi)
        {
            SqlConnection cn = new SqlConnection(Globals.cn_String);


            string queryString = "INSERT INTO equipes (Nom, idTournoi) VALUES('" + Name + "', +" + IdTournoi + ")";
            string queryString2 = "SELECT MAX(Id) FROM equipes";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand(queryString2, cn);
            SqlDataReader reader = command2.ExecuteReader();

            reader.Read();
            int lastId = Convert.ToInt32(reader[0]);

            return lastId;
        }

        public Dictionary<int, string> getAllTournaments()
        {
            Dictionary<int, string> tourneys = new Dictionary<int, string>();

            SqlConnection cn = new SqlConnection(Globals.cn_String);

            string queryString = "SELECT * FROM tournois";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                //Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));

                tourneys.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }

            return tourneys;
        }

        public int getNombreEquipeAvecNom(string nom, int id)
        {
            int nombreEquipe = 0;

            SqlConnection cn = new SqlConnection(Globals.cn_String);

            string queryString = "SELECT * FROM equipes WHERE idTournoi=" + id + " AND CONVERT(VARCHAR, Nom) ='" + nom +"'";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                nombreEquipe = nombreEquipe + 1;
            }

            return nombreEquipe;
        }

        public int GetNombreEquipesDansTournoi(int IdTournoi)
        {
            int nombreEquipes = 0;

            SqlConnection cn = new SqlConnection(Globals.cn_String);

            string queryString = "SELECT * FROM equipes WHERE idTournoi=" + IdTournoi;

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                nombreEquipes = nombreEquipes + 1;
            }

            return nombreEquipes;
        }
    }
}

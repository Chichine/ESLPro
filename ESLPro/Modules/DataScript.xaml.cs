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

        public void DataGet()
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

        public void DataNew(string Name, string BO, int numTeam)
        {
            SqlConnection cn = new SqlConnection(Globals.cn_String);

            
            string queryString = "INSERT INTO tournois (Nom, BO, numTeam) VALUES('" + Name + "', '"+BO+"', +"+ numTeam +")";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            command.ExecuteNonQuery();
        }

        public List<string> getAllTournaments()
        {
            List<string> tourneys = new List<string>();

            SqlConnection cn = new SqlConnection(Globals.cn_String);

            string queryString = "SELECT * FROM tournois";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                //Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));

                tourneys.Add(reader[1].ToString());
            }

            return tourneys;
        }

    }
}

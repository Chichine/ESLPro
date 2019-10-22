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
    /// Logique d'interaction pour tournament_properties.xaml
    /// </summary>
    /// 
    public partial class tournament_properties : Window
    {
        public tournament_properties()
        {
            InitializeComponent();
        }

        public void DataUpdate()
        {
            string cn_String = Properties.Settings.Default.connection_String;

            SqlConnection cn = new SqlConnection(cn_String);

            string queryString = "UPDATE tournoi SET Nom='LeTest' WHERE Id=1";

            SqlCommand command = new SqlCommand(queryString, cn);
            cn.Open();

            command.ExecuteNonQuery();
        }

        

        private void create_Click(object sender, RoutedEventArgs e)
        {
            //DataNew();
           // DataUpdate();


            DataScript Script = new DataScript();

            

            Script.DataNew(Nom.Text, BO.Text, Convert.ToInt32(numTeam.Text));
            //Script.DataGet();

            Properties.Settings.Default.currentTournament = Nom.Text;

            tournament_teams page = new tournament_teams();

            page.Show();
            this.Close();
        }
    }
}

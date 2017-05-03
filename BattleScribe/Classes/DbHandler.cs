using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace BattleScribe.Classes
{
    public class DbHandler
    {
        string conString;
        private SqlCeConnection con;
        private SqlCeCommand com;
        private SqlCeDataReader dReader;

        public DbHandler()
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;

            com = new SqlCeCommand();
            com.CommandType = System.Data.CommandType.Text;
        }

        public void TestCon()
        {
            try
            {
                con.Open();
                System.Windows.MessageBox.Show("Con opend");
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
            }
        }

        public void GetSpells()
        {
            string sql = "SELECT * FROM spells WHERE spell_id = @id";


            try
            {
                using (con)
                {
                    com.Parameters.AddWithValue(@"id", "1");
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();


                    while (dReader.Read())
                    {
                        System.Windows.MessageBox.Show(dReader.GetString(1));
                    }
                    
                    con.Close();
                    com.Parameters.Clear();
                }
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
        }
    }
}

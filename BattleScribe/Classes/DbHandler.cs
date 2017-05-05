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

        //public List<CharacterRace> GetRaces()
        //{
        //    // Add code to gather all races by id. Fill the feature list, too.
        //    string sql = "SELECT * tbl_races";
        //    List<CharacterRace> temp = new List<CharacterRace>();
        //    return temp;
        //}

        public List<Spell> GetSpells()
        {
            List<Spell> SpellList = new List<Spell>();


            string sql = "SELECT * FROM spells";


            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();


                    while (dReader.Read())
                    {
                        Spell s = new Spell();
                        s.SetName(dReader.GetString(1));
                        s.SetDesc(dReader.GetString(8));
                        SpellList.Add(s);
                    }
                    
                    con.Close();
                    com.Parameters.Clear();
                }
                return SpellList;
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
                return null;
            }
        }
    }
}

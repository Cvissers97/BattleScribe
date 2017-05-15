using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Windows;
using BattleScribe.Classes;
using BattleScribe.Classes.Items;

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
            com = new SqlCeCommand();
            com.CommandType = System.Data.CommandType.Text;
        }

        public void TestCon()
        {
            try
            {
                con.Open();
                System.Windows.MessageBox.Show("Con open");
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
            }
        }

        public List<Feature> GetFeaturesByRace(string race)
        {
            List<Feature> features = new List<Feature>();

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT ID FROM RACE WHERE NAME = @Name";
            int race_id = 0;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"name", race);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        race_id = dReader.GetInt32(0);
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }

            sql = "SELECT * FROM RACE_FEATURES WHERE RACE_ID = @ID";
            con = new SqlCeConnection();
            conString = Properties.Settings.Default.conString;
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"ID", race_id);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        Feature feature = new Feature(dReader.GetInt32(0),
                            dReader.GetString(2), dReader.GetString(3));

                        features.Add(feature);
                    }

                    con.Close();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }

            return features;
        }

        public List<Feature> GetFeaturesByClass(string race)
        {
            List<Feature> features = new List<Feature>();

            return features;
        }

        //Method to get a list of all races and its features
        public List<CharacterRace> GetRaces()
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            // Add code to gather all races by id. Fill the feature list, too.
            string sql = "SELECT * FROM Race";
            List<CharacterRace> temp = new List<CharacterRace>();

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
                        CharacterRace r = new CharacterRace(dReader.GetString(1));
                        temp.Add(r);
                    }
                    con.Close();
                    com.Parameters.Clear();
                }
                return temp;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
                return null;
            }
        }

        //Get all spells no filter
        public List<Spell> GetSpells()
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            List<Spell> spellList = new List<Spell>();


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
                        Spell s = new Spell(dReader.GetString(1), (byte)dReader.GetInt32(2),
                             dReader.GetString(3), dReader.GetString(4), dReader.GetString(5),
                             dReader.GetString(6), dReader.GetString(7), dReader.GetString(8), dReader.GetString(9));
                        spellList.Add(s);
                    }
                    
                    con.Close();
                    com.Parameters.Clear();
                }
                return spellList;
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
                return null;
            }
        }

        //Get all spells by class and level
        public List<Spell> GetSpellsByClass(string char_Class, int spellLvl)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            List<Spell> sList = new List<Spell>();
            string sql;
            int class_id = 0;

            sql = "SELECT id FROM Class WHERE name = @name";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"name", char_Class);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();


                    while (dReader.Read())
                    {
                        class_id = dReader.GetInt32(0);   
                    }

                    //con.Close();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }


            sql = "SELECT s.* FROM Class_Spells cSpells INNER JOIN Spells s ON cSpells.spell_id = s.spell_id WHERE cSpells.class_id = @id AND s.spell_level = @lvl";
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"id", class_id);
                    com.Parameters.AddWithValue(@"lvl", spellLvl);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();


                    while (dReader.Read())
                    {
                        Spell s = new Spell(dReader.GetString(1), (byte)dReader.GetInt32(2),
                            dReader.GetString(3), dReader.GetString(4), dReader.GetString(5),
                            dReader.GetString(6), dReader.GetString(7), dReader.GetString(8), dReader.GetString(9));
                        sList.Add(s);
                    }

                    con.Close();
                    com.Parameters.Clear();
                }
                return sList;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
                return null;
            }
        }

        //get all classes
        public List<CharacterClass> GetClasses()
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT * FROM Class";
            List<CharacterClass> temp = new List<CharacterClass>();

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
                        CharacterClass c = new CharacterClass(dReader.GetString(1));
                        temp.Add(c);
                    }
                    con.Close();
                    com.Parameters.Clear();
                }
                return temp;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
                return null;
            }
        }

        public List<Weapon> GetWeapons()
        {
            List<Weapon> weapons = new List<Weapon>();

            return weapons;
        }

        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            List<Spell> sList = new List<Spell>();
            string sql;
            int class_id = 0;

            sql = "";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"name", );
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();


                    while (dReader.Read())
                    {
                        class_id = dReader.GetInt32(0);
                    }

                    //con.Close();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }


            return items;
        }
    }
}

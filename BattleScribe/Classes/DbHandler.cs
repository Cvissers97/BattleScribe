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

        public void InsertLangs(List<bool> langs, int charId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "INSERT INTO Character_Languages (Char_Id, Common, Dwarvish, Elvish, Giant, Gnomish, Goblin, Halfling, Orc, Abyssal, Celestial, Draconic, Deep_Speech, Infernal, Primordial, Sylvan, Undercommon) VALUES (@charId, @com, @dwarf, @elf, @giant, @gnome, @goblin, @halfling, @orc, @aby, @cele, @drac, @deep, @infer, @prim, @sylv, @underco)";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"charId", charId);
                    com.Parameters.AddWithValue(@"com", langs.ElementAt(0));
                    com.Parameters.AddWithValue(@"dwarf", langs.ElementAt(1));
                    com.Parameters.AddWithValue(@"elf", langs.ElementAt(2));
                    com.Parameters.AddWithValue(@"giant", langs.ElementAt(3));
                    com.Parameters.AddWithValue(@"gnome", langs.ElementAt(4));
                    com.Parameters.AddWithValue(@"goblin", langs.ElementAt(5));
                    com.Parameters.AddWithValue(@"halfling", langs.ElementAt(6));
                    com.Parameters.AddWithValue(@"orc", langs.ElementAt(7));
                    com.Parameters.AddWithValue(@"aby", langs.ElementAt(8));
                    com.Parameters.AddWithValue(@"cele", langs.ElementAt(9));
                    com.Parameters.AddWithValue(@"drac", langs.ElementAt(10));
                    com.Parameters.AddWithValue(@"deep", langs.ElementAt(11));
                    com.Parameters.AddWithValue(@"infer", langs.ElementAt(12));
                    com.Parameters.AddWithValue(@"prim", langs.ElementAt(13));
                    com.Parameters.AddWithValue(@"sylv", langs.ElementAt(14));
                    com.Parameters.AddWithValue(@"underco", langs.ElementAt(15));

                    con.Open();
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            con.Close();
        }
            
        

        public void InsertSkills(List<bool> skills, int charId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "INSERT INTO Character_Skills (Char_Id, Acrobatics, Animal_Handeling, Arcana, Athletics, Deception, History, Insight, Intimidation, Investigation, Medicine, Nature, Perception, Performance, Religion, Sleight_Of_Hand, Stealth, Survival) VALUES (@char_Id, @acro, @aniHand, @arc, @athlet, @decep, @hist, @insight, @intim,@invest, @med, @nat, @percep, @perf, @rel, @slhnd, @stealth, @surv)";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"char_Id", charId);
                    com.Parameters.AddWithValue(@"acro", skills.ElementAt(0));
                    com.Parameters.AddWithValue(@"aniHand", skills.ElementAt(1));
                    com.Parameters.AddWithValue(@"arc", skills.ElementAt(2));
                    com.Parameters.AddWithValue(@"athlet", skills.ElementAt(3));
                    com.Parameters.AddWithValue(@"decep", skills.ElementAt(4));
                    com.Parameters.AddWithValue(@"hist", skills.ElementAt(5));
                    com.Parameters.AddWithValue(@"insight", skills.ElementAt(6));
                    com.Parameters.AddWithValue(@"intim", skills.ElementAt(7));
                    com.Parameters.AddWithValue(@"invest", skills.ElementAt(8));
                    com.Parameters.AddWithValue(@"med", skills.ElementAt(9));
                    com.Parameters.AddWithValue(@"nat", skills.ElementAt(10));
                    com.Parameters.AddWithValue(@"percep", skills.ElementAt(11));
                    com.Parameters.AddWithValue(@"perf", skills.ElementAt(12));
                    com.Parameters.AddWithValue(@"rel", skills.ElementAt(13));
                    com.Parameters.AddWithValue(@"slhnd", skills.ElementAt(14));
                    com.Parameters.AddWithValue(@"stealth", skills.ElementAt(15));
                    com.Parameters.AddWithValue(@"surv", skills.ElementAt(16));
                    con.Open();
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            con.Close();
        }

        public int CreateCharacter(Character c)
        {
            List<Feature> features = new List<Feature>();
            int result = 0;

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "INSERT INTO Character(Name, Class, Race, Level, Age, Size, Appearance, Image ,Title, Personality, Ideals, Bonds, Flaws, Backstory, Alignment, IsMale, IsFemale, [STR], [DEX], [CON], [WIS] ,[INT], [CHA], Background) VALUES (@Name, @Class, @Race, @Level, @Age, @Size, @Appearance, @Image ,@Title, @Personality, @Ideals, @Bonds, @Flaws, @Backstory, @alignment, @IsMale, @IsFemale, @Str, @Dex, @Con, @Wis, @Int, @Cha, @Background)";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"Name", c.GetName());
                    com.Parameters.AddWithValue(@"Class", c.GetClass());
                    com.Parameters.AddWithValue(@"Race", c.GetRace());
                    com.Parameters.AddWithValue(@"Level", 1);
                    com.Parameters.AddWithValue(@"Age", c.GetAge());
                    com.Parameters.AddWithValue(@"Size", c.GetSize());
                    com.Parameters.AddWithValue(@"Appearance", c.GetAppearance());
                    com.Parameters.AddWithValue(@"Image", c.GetImage());
                    com.Parameters.AddWithValue(@"Title", c.GetTitle());
                    com.Parameters.AddWithValue(@"Personality", c.GetPersonality());
                    com.Parameters.AddWithValue(@"Ideals", c.GetIdeals());
                    com.Parameters.AddWithValue(@"Bonds", c.GetBonds());
                    com.Parameters.AddWithValue(@"Flaws", c.GetFlaws());
                    com.Parameters.AddWithValue(@"Backstory", c.GetBackstory());
                    com.Parameters.AddWithValue(@"Alignment", c.GetAlignment());
                    com.Parameters.AddWithValue(@"IsMale", c.GetIsMale());
                    com.Parameters.AddWithValue(@"IsFemale", c.GetIsFemale());
                    com.Parameters.AddWithValue(@"Str", c.GetStr());
                    com.Parameters.AddWithValue(@"Dex", c.GetDex());
                    com.Parameters.AddWithValue(@"Con", c.GetCon());
                    com.Parameters.AddWithValue(@"Wis", c.GetWis());
                    com.Parameters.AddWithValue(@"Int", c.GetInt());
                    com.Parameters.AddWithValue(@"Cha", c.GetCha());
                    com.Parameters.AddWithValue(@"Background", c.GetBackGround());
                    //com.Parameters.AddWithValue(@"MiscProfs", c.GetMiscProfs());
                    con.Open();
                    com.ExecuteNonQuery();
                    com.CommandText = "SELECT @@IDENTITY";
                    result = Convert.ToInt32(com.ExecuteScalar());
                    com.Parameters.Clear();
                  
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }

            return result;
        }

        public List<Skill> GetSkillsByCharId(int id)
        {
            List<Skill> skills = new List<Skill>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT Acrobatics, Animal_Handeling, Arcana, Athletics, Deception, History, Insight, Intimidation, Investigation, Medicine, Nature, Perception, Performance, Religion, Sleight_Of_Hand, Stealth, Survival FROM Character_Skills WHERE Char_Id = @Id";
            Character c = new Character();
            List<string> skillNames = c.SkillsList();

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"Id", id);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        for (int i = 0; i < skillNames.Count; i++)
                        {
                            Skill s = new Skill(skillNames.ElementAt(i), dReader.GetBoolean(i));
                            skills.Add(s);
                        }
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            con.Close();
            return skills;
        }

        public List<Language> GetLangsByCharId(int id)
        {
            List<Language> langs = new List<Language>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT Common, Dwarvish, Elvish, Giant, Gnomish, Goblin, Halfling, Orc, Abyssal, Celestial, Draconic, Deep_Speech, Infernal, Primordial, Sylvan, Undercommon FROM Character_Languages WHERE Char_Id = @Id";
            Character c = new Character();
            List<string> langNames = c.LangList();

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"Id", id);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        for (int i = 0; i < langNames.Count; i++)
                        {
                            Language l = new Language(langNames.ElementAt(i), dReader.GetBoolean(i));
                            langs.Add(l);
                        }
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            con.Close();
            return langs;
        }

        public Character GetCharacterById(int id)
        {
            Character c = null;

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT * FROM Character WHERE Id = @Id";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"Id", id);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        c = new Character(dReader.GetInt32(0), dReader.GetString(1), dReader.GetString(9), dReader.GetString(5), dReader.GetString(6), dReader.GetString(15), dReader.GetBoolean(17), dReader.GetBoolean(16), dReader.GetString(12), dReader.GetString(11), dReader.GetString(7), dReader.GetString(13), dReader.GetString(14), dReader.GetByte(18), dReader.GetByte(19), dReader.GetByte(20), dReader.GetByte(21), dReader.GetByte(22), dReader.GetByte(23), dReader.GetInt32(2), dReader.GetString(10), dReader.GetInt32(24).ToString(), dReader.GetInt32(3).ToString(), dReader.GetInt32(4));
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            con.Close();



            return c;
        }

        public List<Character> GetCharacterForMain()
        {
            List<Character> temp = new List<Character>();

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT Id, Image, Name, Class, Level  FROM Character";

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
                        temp.Add(new Character(dReader.GetInt32(0), (byte[])dReader["Image"], dReader.GetString(2),dReader.GetInt32(3), dReader.GetInt32(4)));
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            con.Close();
            return temp;

        }

        public List<Feature> GetFeaturesByRace(string name)
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
                    com.Parameters.AddWithValue(@"name", name);
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

        public void InsertSpells(int[] spellId, int charId)
        {
            string sql = "INSERT INTO Character_SpellList (Char_Id, Spell_Id, Is_Prepared) VALUES (@Char_Id, @SpellId, 0)";

            for (int i = 0; i < spellId.Length; i++)
            {
                conString = Properties.Settings.Default.conString;
                con = new SqlCeConnection();
                con.ConnectionString = conString;
                try
                {
                    using (con)
                    {
                        com.Connection = con;
                        com.CommandText = sql;
                        com.Parameters.AddWithValue(@"Char_Id", charId);
                        com.Parameters.AddWithValue(@"SpellId", spellId[i]);
                        con.Open();
                        com.ExecuteNonQuery();

                        com.Parameters.Clear();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message.ToString());
                    con.Close();
                }
            }
            con.Close();
                
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
                        CharacterRace r = new CharacterRace(dReader.GetInt32(0),dReader.GetString(1));
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
                        Spell s = new Spell(dReader.GetInt32(0).ToString(), dReader.GetString(1), (byte)dReader.GetInt32(2),
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
                        Spell s = new Spell(dReader.GetInt32(0).ToString(), dReader.GetString(1), (byte)dReader.GetInt32(2),
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
                        CharacterClass c = new CharacterClass(dReader.GetString(1), dReader.GetInt32(0));
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
                   // com.Parameters.AddWithValue(@"name", );
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

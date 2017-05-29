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

        public void CreateMoney(int charId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
			string sql = "INSERT INTO Character_Money (CharId, copper, silver, gold, platinum) VALUES (@CharId, 0, 0, 0, 0)";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
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
            int maxHP = GetMaxHPByClass(c.GetClass());

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "INSERT INTO Character(Name, Class, Race, Level, Age, Size, Appearance, Image ,Title, Personality, Ideals, Bonds, Flaws, Backstory, Alignment, IsMale, IsFemale, [STR], [DEX], [CON], [WIS] ,[INT], [CHA], Background, MAX_HP, CUR_HP, Experience) VALUES (@Name, @Class, @Race, @Level, @Age, @Size, @Appearance, @Image ,@Title, @Personality, @Ideals, @Bonds, @Flaws, @Backstory, @alignment, @IsMale, @IsFemale, @Str, @Dex, @Con, @Wis, @Int, @Cha, @Background, @MAX_HP, @MAX_HP, 0)";

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
                    com.Parameters.AddWithValue(@"MAX_HP", maxHP);

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

        public void UpdateMoney(int charId, int copper, int silver, int gold, int platinum)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "UPDATE CHARACTER_MONEY SET copper = @copper, silver = @silver, gold = @gold, platinum = @platinum WHERE CharId = @charId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
                    com.Parameters.AddWithValue(@"copper", copper);
                    com.Parameters.AddWithValue(@"silver", silver);
                    com.Parameters.AddWithValue(@"gold", gold);
                    com.Parameters.AddWithValue(@"platinum", platinum);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();
                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception error)
            {
                con.Close();
                MessageBox.Show(error.ToString());
                throw;
            }
        }

        public int[] GetMoney(int charId)
        {
            int[] dosh = new int[4];

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT copper, silver, gold, platinum FROM Character_Money WHERE CharId = @CharId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        dosh[0] = dReader.GetInt32(0);
                        dosh[1] = dReader.GetInt32(1);
                        dosh[2] = dReader.GetInt32(2);
                        dosh[3] = dReader.GetInt32(3);
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception error)
            {
                con.Close();
                MessageBox.Show(error.ToString());
                throw;
            }

            return dosh;
        }

        public List<string> GetBackgrounds()
        {
            List<string> backgrounds = new List<string>();

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT Name FROM Backgrounds ORDER BY Name";

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
                        backgrounds.Add(dReader.GetString(0));
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception error)
            {
                con.Close();
                MessageBox.Show(error.ToString());
                throw;
            }

            return backgrounds;
        }

        public int GetRaceMovementById(int raceId)
        {
            int move = 30;

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT Movement_Speed FROM RACE WHERE ID = @ID";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"Id", raceId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        move = dReader.GetInt32(0);
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception error)
            {
                con.Close();
                MessageBox.Show(error.ToString());
                throw;
            }

            return move;
        }

        public int GetMaxHPByClass(int classId)
        {
            int hp = 0;

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT HP_LVL_1 FROM CLASS WHERE ID = @ID";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"Id", classId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        hp = dReader.GetInt32(0);
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

            return hp;
        }

        public List<Item> GetAllAdventuringGear()
        {
            List<Item> items = new List<Item>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT adv.*, i.Id FROM Items i JOIN Adventuring_Gear adv ON i.Item_Id = adv.Id AND i.Type_Id = 3";

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
                        items.Add(new Item(dReader.GetInt32(4), dReader.GetString(1), dReader.GetString(2), dReader.GetString(3), 3, 0));
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
            return items;
        }


        //WIP
        public void AddWeapon(Weapon w)
        {
            string sql = "INSERT INTO Weapons (Name, Damage, Damage_Type, Weight, Properties, Attunable, Cost_In_Gold, Type, Description, Bonus_Type, Modifier, Bonus_Damage) VALUES (@Char_Id, @SpellId, 0)";

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    
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

        public List<Weapon> GetAllWeapons()
        {
            List<Weapon> weapons = new List<Weapon>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT wep.*, i.Id FROM Items i JOIN Weapons wep ON i.Item_Id = wep.Id AND i.Type_Id = 1";

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
                        weapons.Add(new Weapon(dReader.GetInt32(13), dReader.GetString(1), dReader.GetString(9), dReader.GetString(2), dReader.GetString(8), false, dReader.GetBoolean(6), Convert.ToSingle(dReader.GetDouble(4)).ToString(), dReader.GetString(11), Convert.ToSingle(dReader.GetDouble(12)), dReader.GetString(3), "geen idee", 0));
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                con.Close();
            }
            con.Close();
            return weapons;
        }

        public List<Armour> GetAllArmour()
        {
            List<Armour> armour = new List<Armour>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT ar.*, i.Id FROM Items i JOIN Armour ar ON i.Item_Id = ar.Id AND i.Type_Id = 2";

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
                        armour.Add(new Armour(dReader.GetInt32(13), dReader.GetString(1), dReader.GetString(2), "Armour", false, dReader.GetBoolean(12), Convert.ToSingle(dReader.GetDouble(9)).ToString(), dReader.GetBoolean(8), dReader.GetInt32(5), dReader.GetInt32(4), dReader.GetString(6), 1, dReader.GetInt32(7), Convert.ToSingle(dReader.GetDouble(10)).ToString()));
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                con.Close();
            }
            con.Close();
            return armour;
        }

        public List<Spell> GetSpellsByCharId(int id)
        {
            List<Spell> spells = new List<Spell>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT s.*, list.Is_Prepared  FROM Character_SpellList list JOIN Spells s ON list.Spell_Id = s.Spell_Id WHERE list.Char_Id = @id ";

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
                        Spell s = new Spell(Convert.ToString(dReader.GetInt32(0)), dReader.GetString(1), Convert.ToByte(dReader.GetInt32(2)), dReader.GetString(3), dReader.GetString(4), dReader.GetString(5), dReader.GetString(6), dReader.GetString(7), dReader.GetString(8), dReader.GetString(9), dReader.GetBoolean(10));
                        spells.Add(s);
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
            return spells;
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
                        c = new Character(dReader.GetInt32(0), dReader.GetString(1),
                            dReader.GetString(9), dReader.GetString(5),
                            dReader.GetString(6), dReader.GetString(15),
                            dReader.GetBoolean(17), dReader.GetBoolean(16),
                            dReader.GetString(12), dReader.GetString(11),
                            dReader.GetString(7), dReader.GetString(13),
                            dReader.GetString(14), dReader.GetByte(18), 
                            dReader.GetByte(19), dReader.GetByte(20), 
                            dReader.GetByte(22), dReader.GetByte(21), 
                            dReader.GetByte(23), dReader.GetInt32(2), 
                            dReader.GetString(10), dReader.GetInt32(24).ToString(), dReader.GetInt32(3).ToString(), dReader.GetInt32(4));
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
                        temp.Add(new Character(dReader.GetInt32(0), (byte[])dReader["Image"], dReader.GetString(2), dReader.GetInt32(3), dReader.GetInt32(4)));
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

        public List<Feature> GetFeaturesByRaceId(int id)
        {
            List<Feature> features = new List<Feature>();
            string sql = "SELECT * FROM RACE_FEATURES WHERE RACE_ID = @ID";
            con = new SqlCeConnection();
            conString = Properties.Settings.Default.conString;
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"ID", id);
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

        public List<Feature> GetFeaturesByClass(string classId)
        {
            List<Feature> features = new List<Feature>();

            string sql = "SELECT Id, NAME, DESCRIPTION FROM CLASS_FEATURES WHERE CLASS_ID = @classId";
            con = new SqlCeConnection();
            conString = Properties.Settings.Default.conString;
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"classId", classId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        Feature feat = new Feature(dReader.GetInt32(0), dReader.GetString(1), dReader.GetString(2));
                        features.Add(feat);
                    }

                    con.Close();
                    com.Parameters.Clear();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                con.Close();
                throw;
            }

            return features;
        }

        public int GetHitDiceByClass(int _class)
        {
            int hit = 0;

            string sql = "SELECT HIT_DICE FROM CLASS WHERE ID = @ID";
            con = new SqlCeConnection();
            conString = Properties.Settings.Default.conString;
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"ID", _class);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        hit = Convert.ToInt32(dReader.GetString(0));
                    }

                    con.Close();
                    com.Parameters.Clear();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                throw;
            }

            MessageBox.Show(hit.ToString());
            return hit;
        }

        public string[] GetSavingThrowByClass(int id)
        {
            string[] throws = new string[2];

            string sql = "SELECT Saving_Throw1, Saving_Throw2 FROM Class WHERE id = @id";
            con = new SqlCeConnection();
            conString = Properties.Settings.Default.conString;
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"id", id);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        throws[0] = dReader.GetString(0);
                        throws[1] = dReader.GetString(1);
                    }

                    con.Close();
                    com.Parameters.Clear();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                throw;
            }

            return throws;
        }

        public void PrepareSpells(List<int> spellIds, int charId)
        {
            //Unprepare all other spells
            string sql = "UPDATE Character_SpellList SET Is_Prepared = 0 WHERE Char_Id = @CharId";
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
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

            sql = "UPDATE Character_SpellList SET Is_Prepared = 1 WHERE Spell_Id = @spellId AND Char_Id = @CharId";

            foreach (int i in spellIds)
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
                        com.Parameters.AddWithValue(@"CharId", charId);
                        com.Parameters.AddWithValue(@"SpellId", i);
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

        public void InsertSpells(int[] spellId, int charId, bool[] prepared)
        {
            DeleteSpells(charId);
            string sql = "INSERT INTO Character_SpellList (Char_Id, Spell_Id, Is_Prepared) VALUES (@Char_Id, @SpellId, @prepared)";

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
                        if (prepared != null)
                            com.Parameters.AddWithValue(@"prepared", prepared[i]);
                        else
                            com.Parameters.AddWithValue(@"prepared", 0);
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
                        CharacterRace r = new CharacterRace(dReader.GetInt32(0), dReader.GetString(1));
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


            string sql = "SELECT * FROM spells ORDER BY spell_name";


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
                             dReader.GetString(6), dReader.GetString(7), dReader.GetString(8), dReader.GetString(9), false);
                        spellList.Add(s);
                    }

                    con.Close();
                    com.Parameters.Clear();
                }
                return spellList;
            }
            catch (Exception e)
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
                            dReader.GetString(6), dReader.GetString(7), dReader.GetString(8), dReader.GetString(9), false);
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

        public CharacterClass GetClassById(int classId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT * FROM Class WHERE id = @id";
            CharacterClass temp = new CharacterClass();

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"id", classId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        temp = new CharacterClass(dReader.GetString(1), dReader.GetInt32(0), dReader.GetString(2), dReader.GetString(3), dReader.GetString(7), dReader.GetString(8), dReader.GetString(9));
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

        public List<int> GetCharacterClassFeaturesIds(int charId)
        {
            List<int> featureIds = new List<int>();
            string sql;

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            sql = "SELECT FeatureId FROM CHARACTER_FEATURES WHERE CharId = @charId";

            try
            {
                using (con)
                {
                    com.Parameters.AddWithValue(@"charId", charId);
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        featureIds.Add(dReader.GetInt32(0));
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
            }

            return featureIds;
        }

        public bool AddFeatureToCharacter(int characterId, int classFeatureId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT COUNT(*) FROM CHARACTER_FEATURES WHERE CharId = @charId AND FeatureId = @featureId";
            int count = 0;

            try
            {
                using (con)
                {
                    com.Parameters.AddWithValue(@"charId", characterId);
                    com.Parameters.AddWithValue(@"featureId", classFeatureId);
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        count = dReader.GetInt32(0);
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
                return false;
            }

            if (count > 0)
            {
                return false;
            }

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            sql = "INSERT INTO CHARACTER_FEATURES(CharId, FeatureId)VALUES(@charId, @featureId)";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"charId", characterId);
                    com.Parameters.AddWithValue(@"featureId", classFeatureId);

                    con.Open();
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            return true;
        }

        public void AddExperience(int charId, int amount)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "Update Character SET Experience = Experience + @amount WHERE  Id = @CharId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.Parameters.AddWithValue(@"charId", charId);
                    com.Parameters.AddWithValue(@"amount", amount);
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }

            con.Close();
        }

        public void RemoveFeatures(int charId, List<int> featureIds)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "DELETE FROM CHARACTER_FEATURES WHERE FeatureId = @featureID AND CharId = @charId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();

                    foreach (int i in featureIds)
                    {
                        com.Parameters.AddWithValue(@"charId", charId);
                        com.Parameters.AddWithValue(@"featureId", i);
                        com.ExecuteNonQuery();
                        com.Parameters.Clear();
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }

            con.Close();
        }

        public void RemoveFeats(int charId, List<int> featIds)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "DELETE FROM CHARACTER_FEATS WHERE FeatId = @featId AND CharId = @charId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();

                    foreach (int i in featIds)
                    {
                        com.Parameters.AddWithValue(@"charId", charId);
                        com.Parameters.AddWithValue(@"featId", i);
                        com.ExecuteNonQuery();
                        com.Parameters.Clear();
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }

            con.Close();
        }


        public bool AddFeatToCharacter(int characterId, int classFeatId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT COUNT(*) FROM CHARACTER_FEATS WHERE CharId = @charId AND FeatId = @featId";
            int count = 0;

            try
            {
                using (con)
                {
                    com.Parameters.AddWithValue(@"charId", characterId);
                    com.Parameters.AddWithValue(@"featId", classFeatId);
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        count = dReader.GetInt32(0);
                    }

                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
                return false;
            }

            if (count > 0)
            {
                return false;
            }

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            sql = "INSERT INTO CHARACTER_FEATS(CharId, FeatId)VALUES(@charId, @featId)";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"charId", characterId);
                    com.Parameters.AddWithValue(@"featId", classFeatId);

                    con.Open();
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            return true;

        }

        public List<int> GetCharacterClassFeatIds(int charId)
        {
            List<int> featIds = new List<int>();
            string sql;

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            sql = "SELECT FeatId FROM CHARACTER_FEATS WHERE CharId = @charId";

            try
            {
                using (con)
                {
                    com.Parameters.AddWithValue(@"charId", charId);
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        featIds.Add(dReader.GetInt32(0));
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
            }

            return featIds;
        }

        public List<Feat> GetAllFeats()
        {
            List<Feat> feats = new List<Feat>();

            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT Name, Description, Prereq, Id FROM Feats";

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
                        Feat temp = new Feat(dReader.GetString(0), dReader.GetString(1),
                            dReader.GetString(2), dReader.GetInt32(3));

                        feats.Add(temp);
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
            }

            return feats;
        }

        public void DeleteSpells(int charId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "DELETE FROM Character_SpellList WHERE Char_Id = @charId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();

                    com.Parameters.AddWithValue(@"charId", charId);
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }

            con.Close();
        }

        public void DeleteInventory(int charId)
        {
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "DELETE FROM Character_Inventory WHERE Char_Id = @charId";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();

                    com.Parameters.AddWithValue(@"charId", charId);
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }

            con.Close();
        }

        public void InsertInventory(List<Item> allItems, int charId)
        {
            DeleteInventory(charId);
            string sql = "INSERT INTO Character_Inventory (Char_Id, Item_Id, Equipped) VALUES (@Char_Id, @Item_Id, @Equipped)";
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    con.Open();
                    foreach (Item i in allItems)
                    {
                        for (int j = 0; j < i.GetQuantity(); j++)
                        {
                            com.Parameters.AddWithValue(@"Char_Id", charId);
                            com.Parameters.AddWithValue(@"Item_Id", i.GetId());
                            com.Parameters.AddWithValue(@"Equipped", i.GetEquip());
                            com.ExecuteNonQuery();
                            com.Parameters.Clear();
                        }

                    }

                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
                con.Close();
            }
            
            con.Close();
        }

        public List<Weapon> GetWeaponsByCharId(int charId)
        {
            List<Weapon> weapons = new List<Weapon>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT  w.*, i.Id, charInv.Id, charInv.Equipped FROM Character_Inventory charInv JOIN Items i ON charInv.Item_id = i.Id JOIN Weapons w ON i.Item_Id = w.Id AND i.Type_Id = 1 WHERE charInv.Char_Id = @CharId ";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        bool duplicate = false;
                        Weapon w = new Weapon(dReader.GetInt32(13), dReader.GetString(1), dReader.GetString(9), dReader.GetString(2), "Weapon", false, dReader.GetBoolean(6), Convert.ToSingle(dReader.GetDouble(4)).ToString(), dReader.GetString(11), Convert.ToSingle(dReader.GetDouble(12)), dReader.GetString(3), "geen idee", 0, dReader.GetInt32(14));
                        w.SetEquip(dReader.GetBoolean(15));
                        foreach (Weapon wep in weapons)
                        {
                            if (wep.GetName() == w.GetName() && wep.GetEquip() == w.GetEquip())
                            {
                                wep.IncrementQuantity();
                                duplicate = true;
                                break;
                            }
                        }

                        if (!duplicate)
                        {
                            weapons.Add(w);
                        }
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
            }

            return weapons;
        }

        public List<Armour> GetArmoursByCharId(int charId)
        {
            List<Armour> armours = new List<Armour>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT  a.*, i.Id, charInv.Id, charInv.Equipped FROM Character_Inventory charInv JOIN Items i ON charInv.Item_id = i.Id JOIN Armour a ON i.Item_Id = a.Id AND i.Type_Id = 2 WHERE charInv.Char_Id = @CharId ";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        bool duplicate = false;
                        Armour a = new Armour(dReader.GetInt32(13), dReader.GetString(1), dReader.GetString(2), "Armour", false, dReader.GetBoolean(12), Convert.ToSingle(dReader.GetDouble(9)).ToString(), dReader.GetBoolean(8), dReader.GetInt32(5), dReader.GetInt32(4), dReader.GetString(6), 1, dReader.GetInt32(7), Convert.ToSingle(dReader.GetDouble(10)).ToString(), dReader.GetInt32(14));
                        a.SetEquip(dReader.GetBoolean(15));
                        foreach (Armour arm in armours)
                        {
                            if (arm.GetName() == a.GetName() && arm.GetEquip() == a.GetEquip())
                            {
                                arm.IncrementQuantity();
                                duplicate = true;
                                break;
                            }
                        }

                        if (!duplicate)
                        {
                            armours.Add(a);
                        }
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
            }

            return armours;
        }


        public List<Item> GetItemsByCharId(int charId)
        {
            List<Item> items = new List<Item>();
            conString = Properties.Settings.Default.conString;
            con = new SqlCeConnection();
            con.ConnectionString = conString;
            string sql = "SELECT  a.*, i.Id, charInv.Id, charInv.Equipped FROM Character_Inventory charInv JOIN Items i ON charInv.Item_id = i.Id JOIN Adventuring_Gear a ON i.Item_Id = a.Id AND i.Type_Id = 3 WHERE charInv.Char_Id = @CharId ";

            try
            {
                using (con)
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    com.Parameters.AddWithValue(@"CharId", charId);
                    con.Open();
                    com.ExecuteNonQuery();
                    dReader = com.ExecuteReader();

                    while (dReader.Read())
                    {
                        bool duplicate = false;
                        Item item = new Item(dReader.GetInt32(4), dReader.GetString(1), dReader.GetString(2), dReader.GetString(3), 3, 0);
                        item.SetEquip(dReader.GetBoolean(6));
                        foreach (Item i in items)
                        {
                            if (i.GetName() == item.GetName() && i.GetEquip() == item.GetEquip())
                            {
                                i.IncrementQuantity();
                                duplicate = true;
                                break;
                            }
                        }

                        if (!duplicate)
                        {
                            items.Add(item);
                        }
                    }

                    com.Parameters.Clear();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                com.Parameters.Clear();
                con.Close();
            }

            return items;
        }
    }
}
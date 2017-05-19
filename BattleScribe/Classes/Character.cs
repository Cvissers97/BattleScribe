using BattleScribe.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public struct Skill
    {
        public string name;
        public bool acquired;

        public Skill(string name, bool acquired)
        {
            this.acquired = acquired;
            this.name = name;
        }
    }

    public class Character
    {
        private int id;
        private string name;
        private string title;
        private string age;
        private string size;
        private string alignment;
        private string race;
        private bool isFemale;
        private bool isMale;
        private string bonds;
        private string ideals;
        private string appearance;
        private string flaws;
        private string backstory;
        private byte str;
        private byte dex;
        private byte con;
        private byte _int;
        private byte wis;
        private byte cha;
        private int charClass;
        private string personality;
        private string background;
        private int proficiency;
        private byte[] image;
        private int maxHitPoints;
        private int curHitPoints;
        private int level;
        private int experiencePoints;
        private bool inspiration;

        private CharacterClass cClass;

        private List<Skill> skills;
        private List<Item> items;
        private List<Weapon> weapons;
        private List<Armour> armours;

        public Character()
        {
            str = 8;
            dex = 8;
            con = 8;
            _int = 8;
            wis = 8;
            cha = 8;

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
        }

        //Id constructor, used for testing the inventory system.
        public Character(int id)
        {
            this.id = id;

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            foreach (string s in SkillsList())
            {
                skills.Add(new Skill(s, false));
            }

            str = 10;
            _int = 15;
            wis = 20;
            cha = 40;
            dex = 2;

            proficiency = 2;
            maxHitPoints = 37;
            curHitPoints = maxHitPoints;
        }

        public void ReceiveExperiencePoints(int amount)
        {
            experiencePoints += amount;
        }

        public Character(int id, byte[] image, string name, int charClass, int level)
        {
            this.id = id;
            this.image = image;
            this.name = name;
            this.charClass = charClass;
            this.level = level;
        }

        public Character(string name, string title, string age, string size, string alignment, bool isFemale, bool isMale
            , string bonds, string ideals, string appearance, string flaws, string backstory, byte str, byte dex,
            byte con, byte _int, byte wis, byte cha, int charClass, string personality, string background,
            string charRace, byte[] image)
        {
            this.name = name;
            this.title = title;
            this.age = age;
            this.size = size;
            this.alignment = alignment;
            this.isFemale = isFemale;
            this.isMale = isMale;
            this.bonds = bonds;
            this.ideals = ideals;
            this.appearance = appearance;
            this.flaws = flaws;
            this.backstory = backstory;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this._int = _int;
            this.wis = wis;
            this.cha = cha;
            this.charClass = charClass;
            this.personality = personality;
            this.background = background;
            this.race = charRace;
            this.image = image;

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            foreach (string s in SkillsList())
            {
                skills.Add(new Skill(s, false));
            }

            //For testing
            proficiency = 2;
        }

        public int GetModifier(string skillName)
        {
            int mod = 0;
            double add = 0;

            foreach (Skill skill in skills)
            {
                if (skill.name == skillName)
                {
                    switch (skillName)
                    {
                        default:
                            add = 1337;
                            break;

                        case "Athletics":
                            add = Math.Floor(((double)str - 10) / 2);
                            break;

                        case "Acrobatics":
                            add = Math.Floor(((double)dex - 10) / 2);
                            break;

                        case "Sleight of Hand":
                            add = Math.Floor(((double)dex - 10) / 2);
                            break;

                        case "Stealth":
                            add = Math.Floor(((double)dex - 10) / 2);
                            break;

                        case "Arcana":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "History":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Investigation":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Nature":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Religion":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Animal Handeling":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Insight":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Medicine":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Perception":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Survival":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Deception":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;

                        case "Intimidation":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;

                        case "Performance":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;

                        case "Persuasion":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;
                    }

                    mod += (int)add;

                    if (skill.acquired)
                    {
                        mod += proficiency;
                    }

                    return mod;
                }
            }
            return mod;
        }

        //Calc the modifier for skills
        public string CalcMod(string stat, double raceMod)
        {
            double temp;
            switch (stat)
            {
                case "STR":
                    temp = str;
                    break;
                case "DEX":
                    temp = dex;
                    break;
                case "CON":
                    temp = con;
                    break;
                case "INT":
                    temp = _int;
                    break;
                case "WIS":
                    temp = wis;
                    break;
                case "CHA":
                    temp = cha;
                    break;
                default:
                    temp = 200;
                    break;
            }

            temp = Math.Floor((((temp + raceMod) - 10) / 2));

            if (temp >= 0)
            {
                return "+" + temp.ToString();
            }
            else if (temp < 0)
            {
                return temp.ToString();
            }

            return null;
        }
        

        //create a list of all skills in the game
        public List<string> SkillsList()
        {
            List<string> temp = new List<string>();

            temp.Add("Acrobatics");
            temp.Add("Animal Handeling");
            temp.Add("Arcana");
            temp.Add("Athletics");
            temp.Add("Deception");
            temp.Add("History");
            temp.Add("Insight");
            temp.Add("Intimidation");
            temp.Add("Investigation");
            temp.Add("Medicine");
            temp.Add("Nature");
            temp.Add("Perception");
            temp.Add("Performance");
            temp.Add("Religion");
            temp.Add("Sleight of Hand");
            temp.Add("Stealth");
            temp.Add("Survival");

            return temp;
        }

        //Creates a list of all langs in the game
        public List<string> LangList()
        {
            List<string> temp = new List<string>();

            temp.Add("Common");
            temp.Add("Dwarvish");
            temp.Add("Elvish");
            temp.Add("Giant");
            temp.Add("Gnomish");
            temp.Add("Goblin");
            temp.Add("Halfling");
            temp.Add("Orc");
            temp.Add("Abyssal");
            temp.Add("Celestial");
            temp.Add("Draconic");
            temp.Add("DeepSpeech");
            temp.Add("Infernal");
            temp.Add("Primordial");
            temp.Add("Sylvan");
            temp.Add("Under Common");

            return temp;
        }

        public byte[] GetImage()
        {
            return image;
        }

        public string GetBackGround()
        {
            return background;
        }
        public string GetPersonality()
        {
            return personality;
        }

        public int GetClass()
        {
            return charClass;
        }

        public string GetClassName()
        {
            return cClass.GetName();
        }

        public string GetName()
        {
            return name;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAge()
        {
            return age;
        }

        public string GetSize()
        {
            return size;
        }

        public string GetAlignment()
        {
            return alignment;
        }

        public bool GetIsFemale()
        {
            return isFemale;
        }

        public bool GetIsMale()
        {
            return isMale;
        }

        public string GetBonds()
        {
            return bonds;
        }

        public string GetIdeals()
        {
            return ideals;
        }

        public string GetAppearance()
        {
            return appearance;
        }

        public string GetFlaws()
        {
            return flaws;
        }

        public string GetBackstory()
        {
            return backstory;
        }

        public byte GetStr()
        {
            return str;
        }

        public byte GetDex()
        {
            return dex;
        }

        public byte GetCon()
        {
            return con;
        }

        public byte GetInt()
        {
            return _int;
        }

        public byte GetWis()
        {
            return wis;
        }

        public byte GetCha()
        {
            return cha;
        }

        public void SetStr(byte str)
        {
            this.str = str;
        }

        public void SetDex(byte dex)
        {
            this.dex = dex;
        }

        public void SetCon(byte con)
        {
            this.con = con;
        }

        public void SetInt(byte _int)
        {
            this._int = _int;
        }

        public void SetWis(byte wis)
        {
            this.wis = wis;
        }

        public void SetCha(byte cha)
        {
            this.cha = cha;
        }

        public string GetRace()
        {
            return this.race;
        }

        public void SetRace(string race)
        {
            this.race = race;
        }

        public List<Weapon> GetAllWeapons()
        {
            return weapons;
        }

        public List<Item> GetAllItems()
        {
            return items;
        }

        public List<Armour> GetAllArmours()
        {
            return armours;
        }

        public void AddWeapon(Weapon w)
        {
            if (w != null)
            {
                weapons.Add(w);
            }
        }

        public void AddItem(Item i)
        {
            if (i != null)
            {
                items.Add(i);
            }
        }

        public void AddArmour(Armour a)
        {
            if (a != null)
            {
                armours.Add(a);
            }
        }

        public int GetID()
        {
            return this.id;
        }

        public int GetMaxHealth()
        {
            return maxHitPoints;
        }

        public void SetMaxHealth(int targetHealth)
        {
            maxHitPoints = targetHealth;
        }

        public int GetCurrentHealth()
        {
            return curHitPoints;
        }

        public void SetCurrentHealth(int targetHealth)
        {
            curHitPoints = targetHealth;
        }

        public void ToggleInspiration()
        {
            inspiration = !inspiration;
        }

        public bool GetInspiration()
        {
            if (inspiration == null)
            {
                inspiration = false;
            }

            return inspiration;
        }
    }
}

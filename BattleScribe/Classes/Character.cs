using BattleScribe.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public struct Language
    {
        public string name;
        public bool acquired;

        public Language(string name, bool acquired)
        {
            this.name = name;
            this.acquired = acquired;
        }
    }
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
        private DbHandler db;

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

        // INT, WIS, CHA (etc.)
        private string spellMod;
        private string savingThrow1;
        private string savingThrow2;

        private byte slot1;
        private byte slot2;
        private byte slot3;
        private byte slot4;
        private byte slot5;
        private byte slot6;
        private byte slot7;
        private byte slot8;
        private byte slot9;

        private CharacterClass cClass;

        private List<Feature> raceFeatures;
        private List<Feature> classFeatures;

        private List<Feat> feats;

        private List<Skill> skills;
        private List<Language> langs;
        private List<Item> items;
        private List<Weapon> weapons;
        private List<Armour> armours;

        private List<Spell> knownSpells;

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
            //Base proficiency
            proficiency = 2;

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

            proficiency = 0;
            maxHitPoints = 37;
            curHitPoints = maxHitPoints;
            SetSpellMod();
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
            string charRace, byte[] image, int level)
        {
            //Base proficiency
            proficiency = 2;

            db = new DbHandler();
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
            this.level = level;

            int temp = db.GetMaxHPByClass(charClass);
            maxHitPoints = temp;
            curHitPoints = temp;

            inspiration = false;

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            raceFeatures = db.GetFeaturesByRace(race);
            classFeatures = new List<Feature>();

            foreach (string s in SkillsList())
            {
                skills.Add(new Skill(s, false));
            }

            SetSpellMod();
        }

        public Character(int id ,string name, string title, string age, string size, string alignment, bool isFemale, bool isMale
    , string bonds, string ideals, string appearance, string flaws, string backstory, byte str, byte dex,
    byte con, byte _int, byte wis, byte cha, int charClass, string personality, string background,
    string charRace, int level)
        {
            //Base proficiency
            proficiency = 2;

            db = new DbHandler();
            this.id = id;
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
            this.level = level;

            int temp = db.GetMaxHPByClass(charClass);
            maxHitPoints = temp;
            curHitPoints = temp;

            inspiration = false;

            raceFeatures = db.GetFeaturesByRace(race);
            classFeatures = new List<Feature>();

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            SetSpellMod();
        }

        public void SetSpellMod()
        {
            switch (charClass)
            {
                default:
                    spellMod = "INT";
                    break;
                case 2:
                    //Bard
                    spellMod = "CHA";
                    break;
                case 3:
                    //Cleric
                    spellMod = "WIS";
                    break;
                case 4:
                    //Druid
                    spellMod = "WIS";

                    break;
                case 5:
                    //Fighter
                    spellMod = "INT";
                    break;
                case 7:
                    //Paladin
                    spellMod = "CHA";

                    break;
                case 8:
                    //Ranger
                    spellMod = "WIS";
                    break;
                case 9:
                    //Rogue
                    spellMod = "INT";
                    break;
                case 10:
                    //Sorcerer
                    spellMod = "CHA";
                    break;
                case 11:
                    //Warlock
                    spellMod = "CHA";
                    break;
                case 12:
                    //Wizard
                    spellMod = "INT";
                    break;
            }
        }

        public string GetSpellMod()
        {
            return this.spellMod;
        }

        public int GetModifier(string skillName)
        {
            int mod = 0;
            double add = 0;

            switch (skillName)
            {
                default:
                    break;

                case "STR":
                    add = Math.Floor(((double)str - 10) / 2);
                    return mod + (int)add;

                case "DEX":
                    add = Math.Floor(((double)dex - 10) / 2);
                    return mod + (int)add;

                case "CON":
                    add = Math.Floor(((double)con - 10) / 2);
                    return mod + (int)add;

                case "INT":
                    add = Math.Floor(((double)_int - 10) / 2);
                    return mod + (int)add;

                case "WIS":
                    add = Math.Floor(((double)wis - 10) / 2);
                    return mod + (int)add;

                case "CHA":
                    add = Math.Floor(((double)cha - 10) / 2);
                    return mod + (int)add;
            }

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

        public int CalcCarryWeight()
        {
            int temp = str;
            temp *= 15;
            return temp;
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
            temp.Add("Deep Speech");
            temp.Add("Infernal");
            temp.Add("Primordial");
            temp.Add("Sylvan");
            temp.Add("Under Common");

            return temp;
        }

        public void SetSkillList(List<Skill> skills)
        {
            this.skills = skills;
        }

        public void SetLangList(List<Language> lang)
        {
            this.langs = lang;
        }
        public int GetLevel()
        {
            return level;
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

        public void SetKnownSpells(List<Spell> spells)
        {
            this.knownSpells = spells;
        }

        public List<Spell> GetKnownSpells()
        {
            return this.knownSpells;
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
            if (weapons != null)
            {
                return weapons;
            }
            return new List<Weapon>();
        }

        public List<Item> GetAllItems()
        {
            if (items != null)
            {
                return items;
            }
            return new List<Item>();
        }

        public List<Armour> GetAllArmours()
        {
            if (armours != null)
            {
                return armours;
            }
            return new List<Armour>();
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

        public List<Feature> GetAllFeatures()
        {
            List<Feature> features = new List<Feature>();
            raceFeatures = db.GetFeaturesByRaceId(Convert.ToInt32(race));

            foreach (Feature f in raceFeatures)
            {
                f.isRacial = true;
                features.Add(f);
            }

            foreach (Feature f in classFeatures)
            {
                features.Add(f);
            }

            return features;
        }

        public void SetClassFeatures(List<Feature> input)
        {
            this.classFeatures = input;
        }

        public void SetCharFeats(List<Feat> input)
        {
            this.feats = input;
        }

        public List<Feat> GetFeats()
        {
            return this.feats;
        }

        public void SetSlots(byte slot1, byte slot2, byte slot3, byte slot4,
            byte slot5, byte slot6, byte slot7, byte slot8, byte slot9)
        {
            this.slot1 = slot1;
            this.slot2 = slot2;
            this.slot3 = slot3;
            this.slot4 = slot4;
            this.slot5 = slot5;
            this.slot6 = slot6;
            this.slot7 = slot7;
            this.slot8 = slot8;
            this.slot9 = slot9;
        }

        public void SetSavingThrows(string first, string second)
        {
            savingThrow1 = first;
            savingThrow2 = second;
        }

        public string[] GetSavingThrows()
        {
            string[] throws = new string[2];

            throws[0] = savingThrow1;
            throws[1] = savingThrow2;

            return throws;
        }

        public int GetProfiencyBonus()
        {
            return proficiency;
        }
    }
}

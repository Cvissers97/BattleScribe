using BattleScribe.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleScribe.Classes
{
    public class MoneyManager
    {
        private Character c;
        private DetailScreen detail;
        private PlayScreen play;
        private DbHandler db;

        private int copper;
        private int silver;
        private int gold;
        private int platinum;

        private string setting;

        public MoneyManager()
        {
            
        }

        public MoneyManager(Character c, PlayScreen play)
        {
            this.c = c;
            this.play = play;
            setting = "PLAY";

            Init();
        }

        public MoneyManager(Character c, DetailScreen detail)
        {
            this.c = c;
            this.detail = detail;
            setting = "DETAIL";

            Init();
        }

        private void Init()
        {
            db = new DbHandler();

            int[] dosh = db.GetMoney(c.GetID());

            copper = dosh[0];
            silver = dosh[1];
            gold = dosh[2];
            platinum = dosh[3];

            UpdateDisplay();
        }

        public void SpendMoney(int copper = 0, int silver = 0, int gold = 0, int platinum = 0)
        {
            bool legal = true;

            if (copper > this.copper)
            {
                MessageBox.Show("Insufficient copper.");
                legal = false;
            }
            else
            {
                this.copper -= copper;
            }

            if (silver > this.silver)
            {
                MessageBox.Show("Insufficient silver.");
                legal = false;
            }
            else
            {
                this.silver -= silver;
            }

            if (gold > this.gold)
            {
                MessageBox.Show("Insufficient gold.");
                legal = false;
            }
            else
            {
                this.gold -= gold;
            }

            if (platinum > this.platinum)
            {
                MessageBox.Show("Insufficient platinum.");
                legal = false;
            }
            else
            {
                this.platinum -= platinum;
            }

            if (legal)
            {
                UpdateDisplay();
            }
        }

        public void ReceiveMoney(int copper = 0, int silver = 0, int gold = 0, int platinum = 0)
        {
            this.copper += copper;
            this.silver += silver;
            this.gold += gold;
            this.platinum += platinum;

            UpdateDisplay();
        }

        public void SaveMoney()
        {
            //Save on window closing or save button clicked;
            db.UpdateMoney(c.GetID(), copper, silver, gold, platinum);
        }

        public void UpdateDisplay()
        {
            int total = CalcTotalGold();

            string copperText = "Copper: " + copper;
            string silverText = "Silver: " + silver;
            string goldText = "Gold: " + gold;
            string platText = "Platinum: " + platinum;
            string totalText = "Total gold: " + total;

            switch (setting)
            {
                default:
                    MessageBox.Show("Default MoneyManager constructor used. Call a programmer!");
                    break;

                case "PLAY":
                    play.lbCopper.Content = copperText;
                    play.lbSilver.Content = silverText;
                    play.lbGold.Content = goldText;
                    play.lbPlatinum.Content = platText;
                    play.lbTotalGold.Content = totalText;
                    break;

                case "DETAIL":
                    detail.lbCopper.Content = copperText;
                    detail.lbSilver.Content = silverText;
                    detail.lbGold.Content = goldText;
                    detail.lbPlatinum.Content = platText;
                    detail.lbTotalGold.Content = totalText;
                    break;
            }
        }

        public int CalcTotalGold()
        {
            int result = 0;

            result += (this.platinum * 10);
            result += this.gold;
            result += (this.silver / 10);
            result += (this.copper / 100);

            return result;
        }
    }
}

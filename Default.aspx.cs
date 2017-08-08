using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToluVsMoniGame
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            if (toluCheckBox.Checked && moniCheckBox.Checked)
            {
            int totalwinner = 0;   
            string result = "";
            Random random = new Random();
            int toluHealth = int.Parse(toluTextBox.Text);
            int moniHealth = int.Parse(moniTextBox.Text);

            // Tolu get first bonus
            moniHealth -= random.Next(1, 100);
            int round = 0;
            result += "Round:" + round;
            result += string.Format("<br/>Tolu got first attacks, leaving ,Moni with Health{0}", moniHealth);
            //Battle logics here
            do
            {
                int toluDamage = random.Next(1, 10);
                int moniDamage = random.Next(1, 20);

                toluHealth -= moniDamage;
                moniHealth -= toluDamage;
                result += "<br/>Round:" + ++round; // Try ++round and round++
                result += string.Format("<br/> Tolu causes {0} damage, leaving moni with {1} Health.", toluDamage, moniHealth);
                result += string.Format("<br/> moni causes {0} damage, leaving Tolu with {1} Health.", moniDamage, toluHealth);

            }
            while (toluHealth > 0 && moniHealth > 0);

            if(toluHealth > 0)
            {
                result += "<br/> Tolu wins!";
              // totalwinner += toluHealth ; 
            }
            else
            {
                result+= "<br/> Moni wins!";
               //totalwinner += moniHealth ;
                }
            resultLabel.Text = string.Format( "{0} <br/>  Total win: {1}", result, totalwinner);
            }
            else
            {
                resultLabel.Text = "Please check the boxes";
            }
        }
    }
}

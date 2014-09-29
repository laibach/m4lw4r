using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M4LW4R
{
    class Skill
    {
        public bool hatSkill = false;
        public String SkillName = "";
        public int SkillIndex = 0;
        public String SkillText = "";
        public String Hauptskill = "";
        public bool IstNebenSkill = false;
        public int SkillLevel = 1;
        public int MaximalerSkillLevel = 1;
        public int SkillAufbauFortschritt = 0;


        public Button SkillButton = new Button();

        private Timer SkillAufbauTimer = new Timer();
        private int AufbauZaehler = 0;


        public void initSkill(int PosX,int PosY, int Index)
        {
            SkillButton.Location = new System.Drawing.Point(PosX,PosY);
            SkillButton.Name = SkillName; 
            // SkillButton.Size = new System.Drawing.Size(100, 50);
            SkillButton.Text = SkillName;
            SkillButton.UseVisualStyleBackColor = true;
            SkillButton.BackColor = System.Drawing.Color.Black;
            SkillButton.ForeColor = System.Drawing.Color.LightGreen;
            // SkillButton.Enabled = false;

            SkillIndex = Index;

            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(SkillButton, SkillText);
            SkillButton.Click += new EventHandler(SkillButton_Click);
            SkillButton.Paint += new PaintEventHandler(SkillButton_Paint);

            SkillAufbauTimer.Interval = 250;
            SkillAufbauTimer.Enabled = false;
            SkillAufbauTimer.Tick += new EventHandler(AufbauTimer_Tick);
        }

        private void SkillButton_Click(object sender, EventArgs e)
        {
            // SkillButton.Enabled = false;
            // MessageBox.Show("Skill #" + SkillIndex.ToString() + ": '" + SkillName + "' geklickt.");
            SkillAufbauTimer.Enabled = true;
        }

        private void SkillButton_Paint(object sender, PaintEventArgs e)
        {
            if (SkillAufbauTimer.Enabled)
            {
                e.Graphics.DrawLine(System.Drawing.Pens.Yellow, new System.Drawing.Point(1, 5), new System.Drawing.Point(AufbauZaehler * SkillButton.Size.Width / 100, 5));
            }
        }

        private void AufbauTimer_Tick(object sender, EventArgs e)
        {
            if (AufbauZaehler == 100)
            {
                hatSkill = true;
                SkillButton.ForeColor = System.Drawing.Color.White;
                SkillAufbauTimer.Enabled = false;
                AufbauZaehler = 0;
                SkillButton.Invalidate();
                SkillButton.Update();
            }
            else
            {
                AufbauZaehler++;
                SkillButton.Invalidate();
                SkillButton.Update();
            }
        }
    }
}

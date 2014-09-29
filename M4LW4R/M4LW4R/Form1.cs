using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace M4LW4R
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Skill[] GameSkills = new Skill[9];
        Mission[] GameMissions = new Mission[5];
        SQLiteWrapper mwsqlite = new SQLiteWrapper();

        private void Form1_Load(object sender, EventArgs e)
        {
            // mwsqlite.erstelle_M4lw4rDB();
            HoleSkills();
            HoleMissions();            
        }

        private void HoleMissions()
        {
            GameMissions[0] = new Mission();
            GameMissions[0].hatMission = true;
            GameMissions[0].istHauptmission = true;
            GameMissions[0].MissionsName = "Resource 'PC' gefunden.";
            GameMissions[0].MissionsText = "Ich habe einen PC entdeckt, der von mir nun übernommen wird.";

            GameMissions[1] = new Mission();
            GameMissions[1].hatMission = true;
            GameMissions[1].istHauptmission = true;
            GameMissions[1].MissionsName = "Resource 'Grossrechner' gefunden.";
            GameMissions[1].MissionsText = "Ich habe einen Grossrechner gefunden, der von mit nun übernommen wird.";
            GameMissions[1].brauchtSkill = "Rechner übernehmen";
            GameMissions[1].hatAntwort = 0;
            GameMissions[1].Antwort1 = "";
            GameMissions[1].Antwort1_IstMission = "";
            GameMissions[1].Antwort1_Belohnung_Skill1 = "";
            GameMissions[1].Antwort1_Belohnung_Skill2 = "";
            GameMissions[1].Antwort1_Belohnung_Skill3 = "";
            GameMissions[1].Antwort1_Belohnung_Money = 0;
            GameMissions[1].Antwort1_Belohnung_Resource = "";
            GameMissions[1].Antwort2 = "";
            GameMissions[1].Antwort2_IstMission = "";
            GameMissions[1].Antwort2_Belohnung_Skill1 = "";
            GameMissions[1].Antwort2_Belohnung_Skill2 = "";
            GameMissions[1].Antwort2_Belohnung_Skill3 = "";
            GameMissions[1].Antwort2_Belohnung_Money = 0;
            GameMissions[1].Antwort2_Belohnung_Resource = "";
            GameMissions[1].Antwort3 = "";
            GameMissions[1].Antwort3_IstMission = "";
            GameMissions[1].Antwort3_Belohnung_Skill1 = "";
            GameMissions[1].Antwort3_Belohnung_Skill2 = "";
            GameMissions[1].Antwort3_Belohnung_Skill3 = "";
            GameMissions[1].Antwort3_Belohnung_Money = 0;
            GameMissions[1].Antwort3_Belohnung_Resource = "";

            GameMissions[2] = new Mission();
            GameMissions[2].hatMission = true;
            GameMissions[2].istHauptmission = true;
            GameMissions[2].MissionsName = "Rette die Geisel!";
            GameMissions[2].MissionsText = "Auf einem übernommenen PC habe ich Dokumente über eine Geiselnahme gefunden.";
            GameMissions[2].brauchtSkill = "Geisel";
            GameMissions[2].hatAntwort = 2;
            GameMissions[2].Antwort1 = "Geiselnehmer töten";
            GameMissions[2].Antwort1_IstMission = "Töte den Geiselnehmer";
            GameMissions[2].Antwort1_Belohnung_Skill1 = "";
            GameMissions[2].Antwort1_Belohnung_Skill2 = "";
            GameMissions[2].Antwort1_Belohnung_Skill3 = "";
            GameMissions[2].Antwort1_Belohnung_Money = 0;
            GameMissions[2].Antwort1_Belohnung_Resource = "";
            GameMissions[2].Antwort2 = "Geiselnehmer bei FBI melden";
            GameMissions[2].Antwort2_IstMission = "";
            GameMissions[2].Antwort2_Belohnung_Skill1 = "";
            GameMissions[2].Antwort2_Belohnung_Skill2 = "";
            GameMissions[2].Antwort2_Belohnung_Skill3 = "";
            GameMissions[2].Antwort2_Belohnung_Money = 0;
            GameMissions[2].Antwort2_Belohnung_Resource = "";
            GameMissions[2].Antwort3 = "";
            GameMissions[2].Antwort3_IstMission = "";
            GameMissions[2].Antwort3_Belohnung_Skill1 = "";
            GameMissions[2].Antwort3_Belohnung_Skill2 = "";
            GameMissions[2].Antwort3_Belohnung_Skill3 = "";
            GameMissions[2].Antwort3_Belohnung_Money = 0;
            GameMissions[2].Antwort3_Belohnung_Resource = "";

            GameMissions[3] = new Mission();
            GameMissions[3].hatMission = true;
            GameMissions[3].istHauptmission = false;
            GameMissions[3].MissionsName = "Töte den Geiselnehmer";
            GameMissions[3].MissionsText = "Unser Magier hat ihn getötet";
            GameMissions[3].brauchtSkill = "";
            GameMissions[3].hatAntwort = 0;
            GameMissions[3].Antwort1 = "";
            GameMissions[3].Antwort1_IstMission = "";
            GameMissions[3].Antwort1_Belohnung_Skill1 = "";
            GameMissions[3].Antwort1_Belohnung_Skill2 = "";
            GameMissions[3].Antwort1_Belohnung_Skill3 = "";
            GameMissions[3].Antwort1_Belohnung_Money = 0;
            GameMissions[3].Antwort1_Belohnung_Resource = "";
            GameMissions[3].Antwort2 = "";
            GameMissions[3].Antwort2_IstMission = "";
            GameMissions[3].Antwort2_Belohnung_Skill1 = "";
            GameMissions[3].Antwort2_Belohnung_Skill2 = "";
            GameMissions[3].Antwort2_Belohnung_Skill3 = "";
            GameMissions[3].Antwort2_Belohnung_Money = 0;
            GameMissions[3].Antwort2_Belohnung_Resource = "";
            GameMissions[3].Antwort3 = "";
            GameMissions[3].Antwort3_IstMission = "";
            GameMissions[3].Antwort3_Belohnung_Skill1 = "";
            GameMissions[3].Antwort3_Belohnung_Skill2 = "";
            GameMissions[3].Antwort3_Belohnung_Skill3 = "";
            GameMissions[3].Antwort3_Belohnung_Money = 0;
            GameMissions[3].Antwort3_Belohnung_Resource = "";

            GameMissions[4] = new Mission();
            GameMissions[4].hatMission = true;
            GameMissions[4].istHauptmission = false;
            GameMissions[4].MissionsName = "Geiselnehmer bei FBI melden";
            GameMissions[4].MissionsText = "Unser Magier hat ihn gemeldet";
            GameMissions[4].brauchtSkill = "";
            GameMissions[4].hatAntwort = 0;
            GameMissions[4].Antwort1 = "";
            GameMissions[4].Antwort1_IstMission = "";
            GameMissions[4].Antwort1_Belohnung_Skill1 = "";
            GameMissions[4].Antwort1_Belohnung_Skill2 = "";
            GameMissions[4].Antwort1_Belohnung_Skill3 = "";
            GameMissions[4].Antwort1_Belohnung_Money = 0;
            GameMissions[4].Antwort1_Belohnung_Resource = "";
            GameMissions[4].Antwort2 = "";
            GameMissions[4].Antwort2_IstMission = "";
            GameMissions[4].Antwort2_Belohnung_Skill1 = "";
            GameMissions[4].Antwort2_Belohnung_Skill2 = "";
            GameMissions[4].Antwort2_Belohnung_Skill3 = "";
            GameMissions[4].Antwort2_Belohnung_Money = 0;
            GameMissions[4].Antwort2_Belohnung_Resource = "";
            GameMissions[4].Antwort3 = "";
            GameMissions[4].Antwort3_IstMission = "";
            GameMissions[4].Antwort3_Belohnung_Skill1 = "";
            GameMissions[4].Antwort3_Belohnung_Skill2 = "";
            GameMissions[4].Antwort3_Belohnung_Skill3 = "";
            GameMissions[4].Antwort3_Belohnung_Money = 0;
            GameMissions[4].Antwort3_Belohnung_Resource = "";
        }
        private void HoleSkills()
        {
            panel1.Controls.Clear();
            DoTestSoryBoard();

            int StartX = 10;
            int StartY = 10;
            for (int i = 0; i < SkillStoryBoard.Length; i++)
            {
                GameSkills[i] = new Skill();
                GameSkills[i].SkillName = SkillStoryBoard[i].SkillName;
                GameSkills[i].SkillText = SkillStoryBoard[i].SkillText;
                GameSkills[i].Hauptskill = SkillStoryBoard[i].HauptSkill;
                GameSkills[i].IstNebenSkill = SkillStoryBoard[i].IstNebenSkill;
                // GameSkills[i].SkillButton.Location = new Point(StartX, StartY);
                if (GameSkills[i].IstNebenSkill == false)
                {
                    StartY = StartY + GameSkills[i].SkillButton.Height + 10;
                    StartX = 10;
                } 
                
                GameSkills[i].initSkill(StartX, StartY, i);
                this.panel1.Controls.Add(GameSkills[i].SkillButton);

                StartX = StartX + GameSkills[i].SkillButton.Width + 10;

               
            }
        }

        Skills[] SkillStoryBoard = new Skills[9];

        private void DoTestSoryBoard()
        {
            SkillStoryBoard[0] = new Skills();
            SkillStoryBoard[0].HauptSkill = "Malware Erstellen";
            SkillStoryBoard[0].IstNebenSkill = false;
            SkillStoryBoard[0].SkillName = "Malware";
            SkillStoryBoard[0].SkillText = "Die Software die alles steuert";

            SkillStoryBoard[1] = new Skills();
            SkillStoryBoard[1].HauptSkill = "Malware Erstellen";
            SkillStoryBoard[1].IstNebenSkill = true;
            SkillStoryBoard[1].SkillName = "Resource benutzen";
            SkillStoryBoard[1].SkillText = "Speicher und CPU-Zeit fremder Rechner als Resource benutzen";

            SkillStoryBoard[2] = new Skills();
            SkillStoryBoard[2].HauptSkill = "Malware Erstellen";
            SkillStoryBoard[2].IstNebenSkill = true;
                ;
            SkillStoryBoard[2].SkillName = "Rechner übernehmen";
            SkillStoryBoard[2].SkillText = "Hiermit können fremde Rechner unter ihre Kontrolle gebracht werden";

            SkillStoryBoard[3] = new Skills();
            SkillStoryBoard[3].HauptSkill = "Malware Erstellen";
            SkillStoryBoard[3].IstNebenSkill = true;
            SkillStoryBoard[3].SkillName = "Malware tarnen";
            SkillStoryBoard[3].SkillText = "Malware besser vor Entdeckung schützen";

            SkillStoryBoard[4] = new Skills();
            SkillStoryBoard[4].HauptSkill = "PCs";
            SkillStoryBoard[4].IstNebenSkill = false;
            SkillStoryBoard[4].SkillName = "PCs";
            SkillStoryBoard[4].SkillText = "Hiermit kann ein PC übernommen werden";

            SkillStoryBoard[5] = new Skills();
            SkillStoryBoard[5].HauptSkill = "PCs";
            SkillStoryBoard[5].IstNebenSkill = true;
            SkillStoryBoard[5].SkillName = "Spamversand";
            SkillStoryBoard[5].SkillText = "verdiene Geld durch verschicken von Masenamils";

            SkillStoryBoard[6] = new Skills();
            SkillStoryBoard[6].HauptSkill = "PCs";
            SkillStoryBoard[6].IstNebenSkill = true;
            SkillStoryBoard[6].SkillName = "CPU-Nutzung";
            SkillStoryBoard[6].SkillText = "verdiene Geld durch Vermietung von CPU-Rechenzeit";

            SkillStoryBoard[7] = new Skills();
            SkillStoryBoard[7].HauptSkill = "PCs";
            SkillStoryBoard[7].IstNebenSkill = true;
            SkillStoryBoard[7].SkillName = "Speicher";
            SkillStoryBoard[7].SkillText = "verdiene Geld durch Vermietung von Speicher";

            SkillStoryBoard[8] = new Skills();
            SkillStoryBoard[8].HauptSkill = "Geisel";
            SkillStoryBoard[8].IstNebenSkill = false;
            SkillStoryBoard[8].SkillName = "Geisel";
            SkillStoryBoard[8].SkillText = "Geisel befreien";
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            // wennZufall

            int Anzahl_moegliche_Missionen = 999;

            Mission[] zufallsmissionen = new Mission[Anzahl_moegliche_Missionen];
            int gefundeneMissionsZaehler = 0;
            for (int i=-1; i<GameSkills.Length;i++)
            {
                bool sollSuchen = false;

                String gskill = "";
                if (i == -1)
                {
                    gskill = "";
                    sollSuchen = true;
                }
                else
                {
                    gskill = GameSkills[i].SkillName;
                    if (GameSkills[i].hatSkill)
                        sollSuchen = true;
                }

                if (sollSuchen)
                {
                    Mission[] gefundenMissionen = holeMissionenNachSkill(gskill);
                    if (gefundenMissionen != null)
                    {
                        for (int i2 = 0; i2 < gefundenMissionen.Length; i2++)
                        {
                            zufallsmissionen[gefundeneMissionsZaehler] = new Mission();
                            zufallsmissionen[gefundeneMissionsZaehler] = gefundenMissionen[i2];
                            gefundeneMissionsZaehler++;
                        }
                    }
                }
            }

            if (gefundeneMissionsZaehler > 0)
            {
                // MessageBox.Show("Missionen gefunden: " + gefundeneMissionsZaehler.ToString());
                listBoxMoeglicheMissionen.Items.Clear();
                for (int i3=0; i3<gefundeneMissionsZaehler; i3++)
                {
                    listBoxMoeglicheMissionen.Items.Add(zufallsmissionen[i3].MissionsName + " " + zufallsmissionen[i3].MissionsText);
                }
            }
        }

        private int holeAnzahlMissionenNachSkill(String[] skills)
        {
            int anzahlMissionen = 0;

            for (int i = 0; i < skills.Length; i++)
            {
                String skill = skills[i];
                anzahlMissionen += holeAnzahlMissionenNachSkill(skill);

            }
            return anzahlMissionen;
        }

        private int holeAnzahlMissionenNachSkill(String skill)
        {
            int anzahlMissionen = 0;

            for (int i = 0; i < GameMissions.Length; i++)
            {
                if (GameMissions[i].istHauptmission)
                {
                    if (GameMissions[i].brauchtSkill == skill)
                    {
                        anzahlMissionen++;
                    }
                }
            }

            return anzahlMissionen;
        }

        private Mission[] holeMissionenNachSkill(String skill)
        {
            int anzahlGefundenerMissionen = holeAnzahlMissionenNachSkill(skill);
            if (anzahlGefundenerMissionen > 0)
            {
                Mission[] returnMission = new Mission[anzahlGefundenerMissionen];

                int anzahlGefundenerMissionenZaehler = 0;
                for (int i = 0; i < GameMissions.Length; i++)
                {
                    if (GameMissions[i].istHauptmission)
                    {
                        if (GameMissions[i].brauchtSkill == skill)
                        {
                            returnMission[anzahlGefundenerMissionenZaehler] = new Mission();
                            returnMission[anzahlGefundenerMissionenZaehler] = GameMissions[i];
                            anzahlGefundenerMissionenZaehler++;
                        }
                    }
                }
                if (anzahlGefundenerMissionenZaehler > 0)
                    return returnMission;
            }
            return null;
        }
    }
}

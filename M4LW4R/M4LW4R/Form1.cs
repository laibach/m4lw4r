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
using Microsoft.VisualBasic;


namespace M4LW4R
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxMoeglicheMissionen.SelectedIndexChanged += new EventHandler(listBoxMoeglicheMissionen_SelectedIndexChanged);
        }

        Skill[] GameSkills = new Skill[9];
        Mission[] GameMissions = new Mission[6];
        private decimal playerMoney = 0;
        private List<string> playerResources = new List<string>();
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
            GameMissions[1].hatAntwort = 1;
            GameMissions[1].Antwort1 = "Grossrechner für CPU-Nutzung vermieten";
            GameMissions[1].Antwort1_IstMission = "";
            GameMissions[1].Antwort1_Belohnung_Skill1 = "CPU-Nutzung";
            GameMissions[1].Antwort1_Belohnung_Skill2 = "";
            GameMissions[1].Antwort1_Belohnung_Skill3 = "";
            GameMissions[1].Antwort1_Belohnung_Money = 100;
            GameMissions[1].Antwort1_Belohnung_Resource = "Grossrechner";
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
            GameMissions[2].Antwort2_IstMission = "Geiselnehmer bei FBI melden";
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
            GameMissions[3].MissionsText = "Der Geiselnehmer wurde eliminiert.";
            GameMissions[3].brauchtSkill = "";
            GameMissions[3].hatAntwort = 0;
            GameMissions[3].IstFolgeMission = "Spiel abgeschlossen!";

            GameMissions[4] = new Mission();
            GameMissions[4].hatMission = true;
            GameMissions[4].istHauptmission = false;
            GameMissions[4].MissionsName = "Geiselnehmer bei FBI melden";
            GameMissions[4].MissionsText = "Der Geiselnehmer wurde dem FBI gemeldet. Sie kümmern sich darum.";
            GameMissions[4].brauchtSkill = "";
            GameMissions[4].hatAntwort = 0;
            GameMissions[4].IstFolgeMission = "Spiel abgeschlossen!";

            GameMissions[5] = new Mission();
            GameMissions[5].hatMission = true;
            GameMissions[5].istHauptmission = false;
            GameMissions[5].MissionsName = "Spiel abgeschlossen!";
            GameMissions[5].MissionsText = "Die Geiselnahme wurde beendet. Gute Arbeit.";
            GameMissions[5].brauchtSkill = "";
            GameMissions[5].hatAntwort = 0;
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
            List<Mission> moeglicheMissionen = new List<Mission>();
            HashSet<string> addedMissions = new HashSet<string>();

            // Add unlocked missions
            foreach (Mission mission in GameMissions)
            {
                if (mission.hatMission && mission.istFreigeschaltet && !addedMissions.Contains(mission.MissionsName))
                {
                    moeglicheMissionen.Add(mission);
                    addedMissions.Add(mission.MissionsName);
                }
            }

            // Add missions based on skills
            foreach (Skill skill in GameSkills)
            {
                if (skill.hatSkill)
                {
                    foreach (Mission mission in GameMissions)
                    {
                        if (mission.hatMission && mission.istHauptmission && mission.brauchtSkill == skill.SkillName && !addedMissions.Contains(mission.MissionsName))
                        {
                            moeglicheMissionen.Add(mission);
                            addedMissions.Add(mission.MissionsName);
                        }
                    }
                }
            }
            // Add missions with no required skill
            foreach (Mission mission in GameMissions)
            {
                if (mission.hatMission && mission.istHauptmission && string.IsNullOrEmpty(mission.brauchtSkill) && !addedMissions.Contains(mission.MissionsName))
                {
                    moeglicheMissionen.Add(mission);
                    addedMissions.Add(mission.MissionsName);
                }
            }

            listBoxMoeglicheMissionen.Items.Clear();
            foreach(Mission mission in moeglicheMissionen)
            {
                listBoxMoeglicheMissionen.Items.Add(mission.MissionsName);
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
                if (GameMissions[i].hatMission && GameMissions[i].istHauptmission)
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
            List<Mission> missionen = new List<Mission>();
            for (int i = 0; i < GameMissions.Length; i++)
            {
                if (GameMissions[i].hatMission && GameMissions[i].istHauptmission)
                {
                    if (GameMissions[i].brauchtSkill == skill)
                    {
                        missionen.Add(GameMissions[i]);
                    }
                }
            }
            return missionen.ToArray();
        }

        private void listBoxMoeglicheMissionen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMoeglicheMissionen.SelectedItem == null)
                return;

            String missionName = listBoxMoeglicheMissionen.SelectedItem.ToString();
            Mission selectedMission = getMissionByName(missionName);

            if (selectedMission != null)
            {
                if (selectedMission.MissionsName == "Spiel abgeschlossen!")
                {
                    MessageBox.Show(selectedMission.MissionsText, selectedMission.MissionsName);
                    MessageBox.Show("You have won the game!", "Congratulations!");
                    Application.Exit();
                    return;
                }

                String missionText = selectedMission.MissionsText;
                String answers = "";
                if (selectedMission.hatAntwort > 0)
                {
                    answers += "\n1: " + selectedMission.Antwort1;
                }
                if (selectedMission.hatAntwort > 1)
                {
                    answers += "\n2: " + selectedMission.Antwort2;
                }
                if (selectedMission.hatAntwort > 2)
                {
                    answers += "\n3: " + selectedMission.Antwort3;
                }

                if (selectedMission.hatAntwort > 0)
                {
                    string choiceStr = Interaction.InputBox(missionText + answers, selectedMission.MissionsName, "1");
                    int choice;
                    if (int.TryParse(choiceStr, out choice) && choice > 0 && choice <= selectedMission.hatAntwort)
                    {
                        ProcessMissionChoice(selectedMission, choice);
                    }
                }
                else
                {
                    MessageBox.Show(missionText, selectedMission.MissionsName);
                    if (!string.IsNullOrEmpty(selectedMission.IstFolgeMission))
                    {
                        Mission nextMission = getMissionByName(selectedMission.IstFolgeMission);
                        if(nextMission != null) {
                            nextMission.istFreigeschaltet = true;
                        }
                    }
                    selectedMission.hatMission = false; // Mark as completed
                    listBoxMoeglicheMissionen.Items.Remove(selectedMission.MissionsName);
                }
            }
        }

        private void ProcessMissionChoice(Mission mission, int choice)
        {
            String feedback = "Aktion ausgeführt!";
            // Process rewards based on choice
            if (choice == 1)
            {
                if (!string.IsNullOrEmpty(mission.Antwort1_Belohnung_Skill1))
                    getSkillByName(mission.Antwort1_Belohnung_Skill1).hatSkill = true;
                if (!string.IsNullOrEmpty(mission.Antwort1_Belohnung_Skill2))
                    getSkillByName(mission.Antwort1_Belohnung_Skill2).hatSkill = true;
                if (!string.IsNullOrEmpty(mission.Antwort1_Belohnung_Skill3))
                    getSkillByName(mission.Antwort1_Belohnung_Skill3).hatSkill = true;
                playerMoney += mission.Antwort1_Belohnung_Money;
                if (!string.IsNullOrEmpty(mission.Antwort1_Belohnung_Resource))
                    playerResources.Add(mission.Antwort1_Belohnung_Resource);
                if (!string.IsNullOrEmpty(mission.Antwort1_IstMission))
                {
                    Mission nextMission = getMissionByName(mission.Antwort1_IstMission);
                    if(nextMission != null) {
                        nextMission.istFreigeschaltet = true;
                        feedback += "\nNeue Mission freigeschaltet: " + mission.Antwort1_IstMission;
                    }
                }
            }
            else if (choice == 2)
            {
                if (!string.IsNullOrEmpty(mission.Antwort2_Belohnung_Skill1))
                    getSkillByName(mission.Antwort2_Belohnung_Skill1).hatSkill = true;
                if (!string.IsNullOrEmpty(mission.Antwort2_Belohnung_Skill2))
                    getSkillByName(mission.Antwort2_Belohnung_Skill2).hatSkill = true;
                if (!string.IsNullOrEmpty(mission.Antwort2_Belohnung_Skill3))
                    getSkillByName(mission.Antwort2_Belohnung_Skill3).hatSkill = true;
                playerMoney += mission.Antwort2_Belohnung_Money;
                if (!string.IsNullOrEmpty(mission.Antwort2_Belohnung_Resource))
                    playerResources.Add(mission.Antwort2_Belohnung_Resource);
                if (!string.IsNullOrEmpty(mission.Antwort2_IstMission))
                {
                    Mission nextMission = getMissionByName(mission.Antwort2_IstMission);
                    if(nextMission != null) {
                        nextMission.istFreigeschaltet = true;
                        feedback += "\nNeue Mission freigeschaltet: " + mission.Antwort2_IstMission;
                    }
                }
            }
            else if (choice == 3)
            {
                if (!string.IsNullOrEmpty(mission.Antwort3_Belohnung_Skill1))
                    getSkillByName(mission.Antwort3_Belohnung_Skill1).hatSkill = true;
                if (!string.IsNullOrEmpty(mission.Antwort3_Belohnung_Skill2))
                    getSkillByName(mission.Antwort3_Belohung_Skill2).hatSkill = true;
                if (!string.IsNullOrEmpty(mission.Antwort3_Belohnung_Skill3))
                    getSkillByName(mission.Antwort3_Belohnung_Skill3).hatSkill = true;
                playerMoney += mission.Antwort3_Belohnung_Money;
                if (!string.IsNullOrEmpty(mission.Antwort3_Belohnung_Resource))
                    playerResources.Add(mission.Antwort3_Belohnung_Resource);
                if (!string.IsNullOrEmpty(mission.Antwort3_IstMission))
                {
                    Mission nextMission = getMissionByName(mission.Antwort3_IstMission);
                    if(nextMission != null) {
                        nextMission.istFreigeschaltet = true;
                        feedback += "\nNeue Mission freigeschaltet: " + mission.Antwort3_IstMission;
                    }
                }
            }

            MessageBox.Show(feedback, "Missions-Update");
            mission.hatMission = false; // Mission is completed
            listBoxMoeglicheMissionen.Items.Remove(mission.MissionsName);
        }

        private Skill getSkillByName(string name)
        {
            foreach (Skill skill in GameSkills)
            {
                if (skill.SkillName == name)
                    return skill;
            }
            return null;
        }

        private Mission getMissionByName(string name)
        {
            foreach (Mission mission in GameMissions)
            {
                if (mission.MissionsName == name)
                    return mission;
            }
            return null;
        }
    }
}

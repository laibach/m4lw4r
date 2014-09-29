using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace M4LW4R
{
    public class SQLiteWrapper
    {
        SQLiteConnection sconnection;
        String SQLiteDB = "m4lw4r.db";
        String sSQLiteConnectionString = "";
        private void openConnection()
        {
            if (!System.IO.File.Exists(SQLiteDB))
                SQLiteConnection.CreateFile(SQLiteDB);
            
            sSQLiteConnectionString = "Data Source=" + SQLiteDB + ";Version=3;";
            sconnection = new SQLiteConnection(sSQLiteConnectionString);
            sconnection.Open();
        }

        public SQLiteDataReader doSQL(String SQLStatement)
        {
            if (sconnection == null)
                openConnection();

            if (sconnection.State != System.Data.ConnectionState.Open)
                openConnection();

            SQLiteCommand command = new SQLiteCommand(SQLStatement, sconnection);
            return command.ExecuteReader();
        }

        public void closeConnection()
        {
            sconnection.Close();
        }

        public void erstelle_M4lw4rDB()
        {
            doSQL("CREATE TABLE if not exists Skill (Name NUMERIC NOT NULL , Text VARCHAR, Hauptskill VARCHAR, IstNebenSkill INTEGER NOT NULL , MaximalerSkillLevel INTEGER NOT NULL )");
            doSQL("CREATE TABLE if not exists Missionen (Name VARCHAR, Text varchar, brauchtSkill varchar, hatAntwort integer, Antwort1 varchar, Antwort1_istMission varchar, Antwort1_Belohnung_Skill1 varchar, Antwort1_Belohnung_Skill2 varchar, Antwort1_Belohnung_Skill3 varchar, Antwort1_Belohnung_Money float, Antwort1_Belohnung_Resource varchar, Antwort2 varchar, Antwort2_istMission varchar, Antwort2_Belohnung_Skill1 varchar, Antwort2_Belohnung_Skill2 varchar, Antwort2_Belohnung_Skill3 varchar, Antwort2_Belohnung_Money float, Antwort2_Belohnung_Resource varchar, Antwort3 varchar, Antwort3_istMission varchar, Antwort3_Belohnung_Skill1 varchar, Antwort3_Belohnung_Skill2 varchar, Antwort3_Belohnung_Skill3 varchar, Antwort3_Belohnung_Money float, Antwort3_Belohnung_Resource varchar )");
            doSQL("CREATE TABLE if not exists Resource (Name VARCHAR, Text VARCHAR, benoetigterskill VARCHAR, benoetigterSkillLevel INTEGER, Speicherplatz FLOAT, MIPs FLOAT)");
        }
    }
}

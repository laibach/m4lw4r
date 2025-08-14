using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace M4LW4R
{
    public class SQLiteWrapper
    {
        private readonly string _dbPath = "m4lw4r.db";
        private readonly string _connectionString;

        public SQLiteWrapper()
        {
            _connectionString = $"Data Source={_dbPath};Version=3;";
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
            }
        }

        /// <summary>
        /// Executes a SQL statement that does not return a result set (e.g., INSERT, UPDATE, DELETE, CREATE).
        /// This method uses parameters to prevent SQL injection.
        /// </summary>
        /// <param name="sql">The SQL statement to execute.</param>
        /// <param name="parameters">A dictionary of parameters to use in the SQL statement.</param>
        /// <returns>The number of rows affected.</returns>
        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executes a SQL query that returns a result set (e.g., SELECT).
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">A dictionary of parameters to use in the SQL query.</param>
        /// <returns>A DataTable containing the query results.</returns>
        public DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        public void erstelle_M4lw4rDB()
        {
            ExecuteNonQuery("CREATE TABLE if not exists Skill (Name NUMERIC NOT NULL , Text VARCHAR, Hauptskill VARCHAR, IstNebenSkill INTEGER NOT NULL , MaximalerSkillLevel INTEGER NOT NULL )");
            ExecuteNonQuery("CREATE TABLE if not exists Missionen (Name VARCHAR, Text varchar, brauchtSkill varchar, hatAntwort integer, Antwort1 varchar, Antwort1_istMission varchar, Antwort1_Belohnung_Skill1 varchar, Antwort1_Belohnung_Skill2 varchar, Antwort1_Belohnung_Skill3 varchar, Antwort1_Belohnung_Money float, Antwort1_Belohnung_Resource varchar, Antwort2 varchar, Antwort2_istMission varchar, Antwort2_Belohnung_Skill1 varchar, Antwort2_Belohnung_Skill2 varchar, Antwort2_Belohnung_Skill3 varchar, Antwort2_Belohnung_Money float, Antwort2_Belohnung_Resource varchar, Antwort3 varchar, Antwort3_istMission varchar, Antwort3_Belohnung_Skill1 varchar, Antwort3_Belohnung_Skill2 varchar, Antwort3_Belohnung_Skill3 varchar, Antwort3_Belohnung_Money float, Antwort3_Belohnung_Resource varchar )");
            ExecuteNonQuery("CREATE TABLE if not exists Resource (Name VARCHAR, Text VARCHAR, benoetigterskill VARCHAR, benoetigterSkillLevel INTEGER, Speicherplatz FLOAT, MIPs FLOAT)");
        }
    }
}

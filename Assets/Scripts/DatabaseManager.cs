using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Unity.VisualScripting;
using System;

public class DatabaseManager : MonoBehaviour
{

    private string database = "URI=file:Score.db";


    private static DatabaseManager instance;
    public static DatabaseManager GetInstance()
    {
        if (instance == null)
        {
            instance = new DatabaseManager();
        }
        return instance;
    }

    void Start()
    {
        CreateDB();
    }
    private void CreateDB()
    {
        using (var connection = new SqliteConnection(database))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "create table if not exists HighestScore (" +
                     "player_score INTEGER)";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void insertScore(int score)
    {
        using (var connection = new SqliteConnection(database))
        {
            connection.Open();
            string query = "Insert into HighestScore(player_score) values (@score)";
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@score", score);
                command.ExecuteReader();
            }
        }
    }
    public void updateScore(int score)
    {
        using (var connection = new SqliteConnection(database))
        {
            connection.Open();
            string query = "update HighestScore set player_score=@score";
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@score", score);
                command.ExecuteReader();
            }
        }
    }
    public long getScore()
    {
        using (var connection = new SqliteConnection(database))
        {
            connection.Open();
            string query = "select player_score from HighestScore";
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                SqliteDataReader reader = command.ExecuteReader();
                return (long)reader["player_score"];
            }
        }
    }
}

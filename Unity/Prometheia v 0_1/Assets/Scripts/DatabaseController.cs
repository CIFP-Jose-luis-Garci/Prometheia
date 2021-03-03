using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseController : MonoBehaviour
{

    private string conn;
    private Vector3 posicion = new Vector3(-4.7f, -4.68f, -4.2f);


    // Start is called before the first frame update
    void Awake()
    {
        //Ruta de la base de datos
        conn = "URI=file:" + Application.dataPath + "\\StreamingAssets\\Checkpoint.db";
    }

    public Vector3 leerPartida()
    {
        //Crear una variable de tipo IDbconnection
        IDbConnection dbConn;
        //Inicializas la variable como una SqliteConnection (hereda de IDbConnection)
        dbConn = new SqliteConnection(conn);
        //Abrir la conexion
        dbConn.Open();

        //Crea comando con la consulta select* (saca todos los datos de la tabla puntucaion)
        IDbCommand dbCommand = dbConn.CreateCommand();
        string sqlQuery = "Select * from checkpoint";
        dbCommand.CommandText = sqlQuery;

        //Leer de la base de datos
        IDataReader reader = dbCommand.ExecuteReader();

        //Bucle para leer la tabla
        while (reader.Read())
        {
            posicion = new Vector3(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));

        }

        //Cerrar toda la conexion
        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Close();
        dbConn = null;
        return posicion;
    }


    public void escribirPartida(Vector3 check)
    {
        //Crear una variable de tipo SqliteConnection y le pasas la ruta de la bbdd
        SqliteConnection dbConn = new SqliteConnection(conn);
        //Abrir la conexion
        dbConn.Open();

        //Crea comando con la consulta update 
        SqliteCommand dbCommand = new SqliteCommand(dbConn);
        dbCommand.CommandText = "update checkpoint set x = :x, y = :y, z = :z where ID=1";
        dbCommand.Parameters.Add("x", DbType.Int32).Value = check.x;
        dbCommand.Parameters.Add("y", DbType.Int32).Value = check.y;
        dbCommand.Parameters.Add("z", DbType.Int32).Value = check.z;
        dbCommand.ExecuteNonQuery();



        //Cerrar toda la conexion
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Close();
        dbConn = null;
    }

}

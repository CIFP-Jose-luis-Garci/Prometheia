using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;
using System.IO;

public static class SaveLoad 
{

    public static List<Game> savedGames = new List<Game>();

    //Estatico para llamarlo desde donde sea
    public static void Save()
    {
        //Agrega nuestro juego actual a la lista de partidas guardadas
        savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();

        //FileStream para crear un puntero al archivo para poder enviar los datos
        //Flie.Creat para crear un archivo en la ruta que pasamos como parámetro
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");

        //Llamamos a Serialize de bf para guardar la lista savedGames en nuestro nuevo archivo
        bf.Serialize(file, SaveLoad.savedGames);

        //Cerrar el archivo que hemos creado
        file.Close();
    }

    public static void Load()
    {
        //Comprobamos si existe un archivo de juego guardado
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            //Para leer los datos desde el archivo 
            //Utilizamos File.Open indicando la ruta Application.persistentDataPath y el nombre del archivo savedGames.gd
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);

            //bf. Deserialize(File) busca el archivo en la ubicación que hemos especificados anteriormente y lo deserializa
            //Convertimos nuestro archivo deserializado al tipo de datos que queremos que sea, que en este caso es una lista (List) del tipo Game
            //Luego ponemos la lista como nuestra lista de partidas guardadas
            SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);

            //Cerramos el archivo 
            file.Close();
        }
    }
}

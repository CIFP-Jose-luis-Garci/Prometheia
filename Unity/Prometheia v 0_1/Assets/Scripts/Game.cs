using UnityEngine;
using System.Collections;

//Podemos guardar todas las variables de este script
[System.Serializable]
public class Game 
{
    //Variable estática a una instancia del juego en particular para hacer referencia a la "partida actual" desde cualquier parte del proyecto
    public static Game current;
    //Definir variable para guardar el objeto
    public Character nefilim;

    public Game()
    {
        nefilim = new Character();
    }
}

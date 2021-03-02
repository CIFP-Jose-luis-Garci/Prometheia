using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void goJugar()
    {
        SceneManager.LoadScene("escenariosPasillo");
    }
    public void goCreditos()
    {

    }
    public void goCargar()
    {

    }
    public void goSalir()
    {
        Application.Quit();
    }
}

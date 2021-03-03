using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    ControlPartida controlPartida;

    public void Awake()
    {
        controlPartida = GameObject.Find("ControlPartida").GetComponent<ControlPartida>();
    }
    public void goJugar()
    {
        SceneManager.LoadScene("escenariosPasillo");
    }
    public void goCreditos()
    {

    }
    public void goCargar()
    {
        controlPartida.setContinuar();
        SceneManager.LoadScene("escenariosPasillo");

    }
    public void goSalir()
    {
        Application.Quit();
    }
}

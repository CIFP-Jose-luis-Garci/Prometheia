using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelMuerte : MonoBehaviour
{
    public GameObject muertoPanel;

    BarraDeVida barraDeVida;


    // Start is called before the first frame update
    void Start()
    {
        muertoPanel.SetActive(false);
        barraDeVida = GameObject.Find("Character").GetComponent<BarraDeVida>();
    }

    public void Update()
    {
        if(barraDeVida.vidaActual == 0)
        {
            muertoPanel.SetActive(true);
        }   
    }

    public void goMenu()
    {
        SceneManager.LoadScene("UI");
    }
    public void goJugar()
    {
        SceneManager.LoadScene("escenariosPasillo");
    }
    public void goSalir()
    {
        Application.Quit();
    }
}

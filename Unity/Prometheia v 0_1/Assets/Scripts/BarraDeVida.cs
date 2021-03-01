using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;

    private void Start()
    {
        vidaActual = 100f;
        vidaMaxima = 100f;

        //Ponemos la barra de vida en 1
        UpdateBarra();
    }


    //Creo una función que actuaiza la barra de vida, para que no lo haga en cada fotograma
    void UpdateBarra()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    public void ImpactoBala()
    {
        vidaActual -= 20f;
        UpdateBarra();
    }

}

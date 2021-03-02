using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;

    SpriteRenderer characterRenderer;


    private void Start()
    {
        vidaActual = 100f;
        vidaMaxima = 100f;
        characterRenderer = GameObject.Find("Character").GetComponent<SpriteRenderer>();
        //Ponemos la barra de vida en 1
        UpdateBarra();
    }

    private void Update()
    {
        if(vidaActual == 0)
        {
            muertePersonaje();
        }
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

    public void muertePersonaje()
    {
        characterRenderer.enabled = false;
        Time.timeScale = 0f;
    }

    public void impactoEnemigo()
    {
        vidaActual -= 10f;
        UpdateBarra();
    }
}

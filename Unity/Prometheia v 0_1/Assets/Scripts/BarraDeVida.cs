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

    public AudioClip gruntClip;
    public AudioSource audioSource;

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
        audioSource.PlayOneShot(gruntClip);
        characterRenderer.enabled = false;
        //Invoke("parar", 1f);
        
    }
    public void parar()
    {
        Time.timeScale = 0f;
    }

    public void impactoEnemigo()
    {
        vidaActual -= 10f;
        UpdateBarra();
    }
}

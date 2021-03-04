using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelMuerte : MonoBehaviour
{
    public GameObject muertoPanel;
    public AudioSource botonSource;
    public AudioClip botonClip;


    // Start is called before the first frame update
    void Start()
    {
        muertoPanel.SetActive(false);
        //botonSource = GameObject.Find("SonidoBoton").GetComponent<AudioSource>();
        //botonClip = GameObject.Find("SonidoBoton").GetComponent<AudioClip>();
    }

    public void controlPanel()
    {
        if (muertoPanel.activeSelf)
        {
            muertoPanel.SetActive(false);
        } else
        {
            muertoPanel.SetActive(true);
        }
    }
    public void goMenu()
    {
        botonSource.PlayOneShot(botonClip);
        SceneManager.LoadScene("UI");
    }
    public void goJugar()
    {
        botonSource.PlayOneShot(botonClip);
        Time.timeScale = 1f;
        SceneManager.LoadScene("escenariosPasillo");
    }
    public void goSalir()
    {
        botonSource.PlayOneShot(botonClip);
        Application.Quit();
    }
}

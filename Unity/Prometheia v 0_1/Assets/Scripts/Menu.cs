using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    ControlPartida controlPartida;
    private GameObject menu;
    private GameObject opciones;

    public AudioSource botonSource;
    public AudioClip botonClip;

    public void Awake()
    {
        controlPartida = GameObject.Find("ControlPartida").GetComponent<ControlPartida>();
    }

    public void Start()
    {
        GetComponent<AudioSource>();
        menu = GameObject.Find("Menu");
        opciones = GameObject.Find("Opciones");
        opciones.SetActive(false);
        botonSource = GameObject.Find("SonidoBoton").GetComponent<AudioSource>();
        //botonClip = GameObject.Find("SonidoBoton").GetComponent<AudioClip>();
    }
    public void goJugar()
    {
        botonSource.PlayOneShot(botonClip);
        SceneManager.LoadScene("escenariosPasillo");
    }
    public void goOpciones()
    {
        botonSource.PlayOneShot(botonClip);
        menu.SetActive(false);
        opciones.SetActive(true);
    }
    public void goCargar()
    {
        botonSource.PlayOneShot(botonClip);
        controlPartida.setContinuar();
        SceneManager.LoadScene("escenariosPasillo");

    }
    public void goSalir()
    {
        botonSource.PlayOneShot(botonClip);
        Application.Quit();
    }

    public void goMenu()
    {
        botonSource.PlayOneShot(botonClip);
        menu.SetActive(true);
        opciones.SetActive(false);
    }
}

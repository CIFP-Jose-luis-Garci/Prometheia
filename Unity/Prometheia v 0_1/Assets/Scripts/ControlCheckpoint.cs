using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCheckpoint : MonoBehaviour
{
    private GameObject controlPartida;
    private Transform character;
    private DatabaseController databaseController;
    private bool continuar = false;
    private BarraDeVida barraVida;
    public AudioSource botonSource;
    public AudioClip botonClip;

    private void Awake()
    {
        controlPartida = GameObject.Find("ControlPartida");
        character = GameObject.Find("Character").GetComponent<Transform>();
        databaseController = GameObject.Find("DatabaseController").GetComponent<DatabaseController>();
        barraVida = GameObject.Find("Character").GetComponent<BarraDeVida>();
        //botonSource = GameObject.Find("SonidoBoton").GetComponent<AudioSource>();
        //botonClip = GameObject.Find("SonidoBoton").GetComponent<AudioClip>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(controlPartida != null)
        {
            continuar = controlPartida.GetComponent<ControlPartida>().getContinuar();
        }

        if (continuar)
        {
            cargarPartida();
        }
        else
        {
            character.position = new Vector3(-4.7f, -4.68f, -4.2f);
            databaseController.escribirPartida(character.position);
        }
    }

    public void cargarPartida()
    {
        botonSource.PlayOneShot(botonClip);
        barraVida.revivir();
        character.position = databaseController.leerPartida();

        if (controlPartida != null)
        {
            controlPartida.GetComponent<ControlPartida>().destruir();
        }
    }
    
}

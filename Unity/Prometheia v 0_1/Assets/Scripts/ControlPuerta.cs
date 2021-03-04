using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPuerta : MonoBehaviour
{
    private GameObject mensajePuerta;
    private bool pasar = false;


    private void Awake()
    {
        mensajePuerta = GameObject.Find("mensajePuerta");
    }

    private void Start()
    {
        mensajePuerta.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Boton X mando") && pasar)
        {
            SceneManager.LoadScene("Final");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            mensajePuerta.SetActive(true);
            pasar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            mensajePuerta.SetActive(false);
            pasar = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ConfiguracionSonido : MonoBehaviour
{
    
    public GameObject botonFx;
    public Text encendido;
    private bool cambio = true;
    public AudioSource botonSource;
    public AudioClip botonClip;
    public GameObject volumeSlider;
    public AudioMixer volumeMixer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>();
    }

    public void cambiarSonidos()
    {
        
        cambio = !cambio;
        if(cambio)
        {
            encendido.text = "Encendido";
            botonFx.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            botonSource.mute = false;
            //characterSource.mute = false;
            botonSource.PlayOneShot(botonClip);
        }
        else
        {
            encendido.text = "Apagado";
            botonFx.GetComponent<Image>().color = new Color(1f, 0f, 0f);
            botonSource.mute = true;
            //characterSource.mute = true;
        }
    }

    public void SetVolume (float sliderValue)
    {
        volumeMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}

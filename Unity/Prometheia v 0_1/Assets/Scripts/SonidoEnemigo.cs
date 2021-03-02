using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoEnemigo : MonoBehaviour
{
    public AudioSource stepSource;
    public AudioClip stepClip;

    // Start is called before the first frame update
    void Start()
    {
        stepSource = GameObject.Find("Enemigo").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void step()
    {
        stepSource.Play();
    }
}

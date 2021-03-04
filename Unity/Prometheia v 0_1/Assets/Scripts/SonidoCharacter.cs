using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoCharacter : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip stepClip;
    public AudioClip armandoClip;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>();
        audioSource = GameObject.Find("Character").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void step()
    {
        audioSource.PlayOneShot(stepClip);
    }

    public void armando()
    {
        audioSource.PlayOneShot(armandoClip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoCharacter : MonoBehaviour
{

    public AudioSource auidoSource;
    public AudioClip stepClip;
    public AudioClip armandoClip;


    // Start is called before the first frame update
    void Start()
    {
        auidoSource = GameObject.Find("Character").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void step()
    {
        auidoSource.PlayOneShot(stepClip);
    }

    public void armando()
    {
        auidoSource.PlayOneShot(armandoClip);
    }
}

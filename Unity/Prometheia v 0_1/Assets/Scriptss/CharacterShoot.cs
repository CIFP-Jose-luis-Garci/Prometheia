using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public float cadenciaDisparo;
    public int amo;
    bool disparando;

    public AudioSource audioSource;
    public AudioClip shotClip;

    //Prefab con la bala
    [SerializeField] GameObject balaRMala;
    [SerializeField] GameObject balaRBuena;
    [SerializeField] GameObject balaLMala;
    [SerializeField] GameObject balaLBuena;
    Transform armaPosR;
    Transform armaPosL;

    //Instanciadores para las balas
    [SerializeField] GameObject balaPosL;
    [SerializeField] GameObject balaPosR;

    private Character_Move characterMove;
    private BarraDeVida barraDeVida;

    private void Start()
    {
        characterMove = GameObject.Find("Character").GetComponent<Character_Move>();
        barraDeVida = GameObject.Find("Character").GetComponent<BarraDeVida>();

        cadenciaDisparo = 1f;
        amo = 100;
        disparando = false;

        //Obtenemos la posición de los instanciadores de bala
        armaPosR = balaPosR.transform;
        armaPosL = balaPosL.transform;

    }
    public void Shoot(string mirando)
    {

        StartCoroutine("Disparando", mirando);
        
    }

    public void stopShooting()
    {
        StopCoroutine("Disparando");
    }

    IEnumerator Disparando(string mirando = "R")
    {
        while(amo > 0)
        {
            //print("Disparo del arma" + mirando);
            //Instanciamos la bala, dependiendo de donde miremos
            if (characterMove.cambiarArma == false)
            {
                if (mirando == "R")
                {
                    Instantiate(balaRMala, armaPosR.position, Quaternion.identity);
                    audioSource.PlayOneShot(shotClip);
                }
                else if (mirando == "L")
                {
                    Instantiate(balaLMala, armaPosL.position, Quaternion.identity);
                    audioSource.PlayOneShot(shotClip);
                }
            }
            else
            {
                if (mirando == "R")
                {
                    Instantiate(balaRBuena, armaPosR.position, Quaternion.identity);
                    audioSource.PlayOneShot(shotClip);
                }
                else if (mirando == "L")
                {
                    Instantiate(balaLBuena, armaPosL.position, Quaternion.identity);
                    audioSource.PlayOneShot(shotClip);
                }
            }

            
            yield return new WaitForSeconds(cadenciaDisparo);

        }
    }
}

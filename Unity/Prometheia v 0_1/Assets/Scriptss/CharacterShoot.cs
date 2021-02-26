using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public float cadenciaDisparo;
    public int amo;
    bool disparando;

    //Prefab con la bala
    [SerializeField] GameObject balaR;
    [SerializeField] GameObject balaL;
    Transform armaPosR;
    Transform armaPosL;

    private void Start()
    {
        cadenciaDisparo = 1f;
        amo = 100;
        disparando = false;

        //Obtenemos la posición de los instanciadores de bala
        armaPosR = GameObject.Find("weaponPosR").transform;
        armaPosL = GameObject.Find("weaponPosL").transform;

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
            print("Disparo del arma" + mirando);
            //Instanciamos la bala, dependiendo de donde miremos
            if(mirando == "R")
            {
                Instantiate(balaR, armaPosR.position, Quaternion.identity);
            }
            else if(mirando == "L")
            {
                Instantiate(balaL, armaPosL.position, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(cadenciaDisparo);

        }
    }
}

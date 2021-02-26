using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string dir;
    public float bulletForce = 50f;

    private Rigidbody2D rb2D;

    //Personaje
    Transform characterPos;

    // Start is called before the first frame update
    void Start()
    {
        characterPos = GameObject.Find("Character").transform;
        rb2D = GetComponent<Rigidbody2D>();

        //Aplicamos una fuerza a la bala
        if(dir == "R")
        {
            rb2D.AddForce(Vector2.right * bulletForce, ForceMode2D.Impulse);
        }
        else if(dir == "L")
        {
            rb2D.AddForce(Vector2.left * bulletForce, ForceMode2D.Impulse);

        }

        //Iniciamos la corrutina que mide su distancia al personaj
        StartCoroutine("CheckDistance");
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    IEnumerator CheckDistance()
    {
        for(; ; )
        {
            float dist = Vector3.Distance(characterPos.position, transform.position);
            //print("Distance to other: " + dist);
            //Si la distancia supera 5 unidades la destruimos
            if(dist > 5)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

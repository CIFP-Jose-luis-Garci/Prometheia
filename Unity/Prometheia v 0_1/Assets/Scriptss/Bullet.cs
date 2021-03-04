using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string dir;
    public float bulletForce = 50f;

    private Rigidbody2D rb2D;

    //Personaje
    GameObject personaje;
    Transform characterPos;
    BarraDeVida barraDeVida;
    EnemyMove enemyMove;
    Character_Move characterMove;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Character");
        characterPos = personaje.transform;
        barraDeVida = personaje.GetComponent<BarraDeVida>();
        //enemyMove = GameObject.Find("Enemigo").GetComponent<EnemyMove>();
        characterMove = GameObject.Find("Character").GetComponent<Character_Move>();

        //RigifBody de la bala
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

   

    //Si impacta con cualquier objeto, desaparece
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si lo que ha impactado es el personaje le mandamos un mensaje
        if (collision.gameObject.tag == "Player")
        {
            barraDeVida.SendMessage("ImpactoBala");
        }

        //Si es un enemigo, lo destruimos
        if (collision.gameObject.tag == "Enemy")
        {
            enemyMove = collision.gameObject.GetComponent<EnemyMove>();

            if (characterMove.cambiarArma == false)
            {
                enemyMove.SendMessage("ImpactoBalaMala");
                barraDeVida.SendMessage("sangrarArmaMala");
            }
            else
            {
                enemyMove.SendMessage("ImpactoBalaBuena");
                barraDeVida.SendMessage("sanarArmaBuena");
            }
        }

        Destroy(this.gameObject);
    }

    IEnumerator CheckDistance()
    {
        for(; ; )
        {
            float dist = Vector3.Distance(characterPos.position, transform.position);
            print("Distance to other: " + dist);
            //Si la distancia supera 9 unidades se ha salido de pantalla y la destruimos
            if(dist > 15)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  
    Rigidbody2D rb2D;
    Animator anim;
    RaycastHit2D hit;
    CharacterShoot characterShoot;

    public float speed = 0.5f;
    public bool disparar = false;

    //Distancia a la que se lanza la "midada" (raycast)
    [SerializeField] float distancia;

    //Tiempo que determina cuándo se gira el enemigo
    public float rondaTime;
    [SerializeField] bool correrDerecha;

    public float vidaTotalE;
    public float vidaActualE;


    void Start()
    {

        vidaActualE = 30f;
        vidaTotalE = 30f;

        //Desactivamos esta opción para que los RayCast no se detecten a sí mismmos
        Physics2D.queriesStartInColliders = false;

        //Componentes del objeto
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        characterShoot = GetComponent<CharacterShoot>();
        

        //Distancia a la que detecta al enemigo
        distancia = 11f;

        //Tiempo de ronda e iniciamos la ronda
        rondaTime = 2f;
        correrDerecha = true;
        StartCoroutine("Ronda");

        
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        //creamos un raycast a la altura de los ojos
        // Creamos un Vector 2 a la altura de los ojos del enemigo
        Vector2 eyesPos = transform.position + new Vector3(0, 1.2f, 0);

        
        //Dependiendo de hacia dónde esté mirando y si no estamos disparando

        if (correrDerecha == false)
        {
            //Si no está disparando, lo movemos
            if(disparar == false)
            {
                rb2D.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
            
            //Comprobamos si ve al jugador
            hit = Physics2D.Raycast(eyesPos, Vector2.left, distancia);
            //Dibujamos una línea que nos muestra hacia donde mira
            Debug.DrawRay(eyesPos, Vector2.left * distancia, Color.red);
        }
        else
        {
            if (disparar == false)
            {
                rb2D.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            hit = Physics2D.Raycast(eyesPos, Vector2.right, distancia);
            //Dibujamos una línea que nos muestra hacia donde mira
            Debug.DrawRay(eyesPos, Vector2.right * distancia, Color.red);
        }


        CheckPlayerPos();
        
    }

    void CheckPlayerPos()
    {
       
        // Si su mirada se cruza con un objeto con el tag "Player"
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            print("Ha impactado" + hit.collider.tag);
            disparar = true;
            anim.SetBool("Disparar", disparar);
            //anim.SetBool("Corriendo", false);

        }
        else if(hit.collider == null)
        {
            disparar = false;
            anim.SetBool("Disparar", disparar);
            anim.SetBool("Corriendo", true);
            //print("ha dejado de impactar");
            //Dejamos de disparar 
            characterShoot.SendMessage("stopShooting");
        }

        
    }

    //Creamos una ronda
    IEnumerator Ronda()
    {
        
        for( ;  ;)
        {
            //Siempre que no estemos disparando
            if(disparar == false)
            {
                if (correrDerecha == true)
                {
                    correrDerecha = false;
                    anim.SetBool("CorrerDerecha", correrDerecha);
                }
                else
                {
                    correrDerecha = true;
                    anim.SetBool("CorrerDerecha", correrDerecha);
                }
            }
            

            yield return new WaitForSeconds(rondaTime);
        }
    }

    public void ImpactoBalaMala()
    {
        vidaActualE -= 10f;
        muerte();
    }

    public void ImpactoBalaBuena()
    {
        vidaActualE -= 7f;
        muerte();
    }

    private void muerte()
    {
        if (vidaActualE <= 0)
        {
            Destroy(gameObject);
        }
    }

}

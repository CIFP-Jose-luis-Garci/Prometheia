using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  
    Rigidbody2D rb2D;
    Animator anim;

    //Distancia a la que se lanza la "midada" (raycast)
    [SerializeField] float distancia;


    void Start()
    {
        //Desactivamos esta opción para que los RayCast no se detecten a sí mismmos
        Physics2D.queriesStartInColliders = false;

        //Componentes del objeto
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Distancia a la que detecta al enemigo
        distancia = 5f;
    }

    void FixedUpdate()
    {
        // Creamos un Vector 2 a la altura de los ojos del enemigo
        Vector2 eyesPos = transform.position + new Vector3(0, 1.2f, 0);
        RaycastHit2D hit = Physics2D.Raycast(eyesPos, Vector2.left, distancia);
        
        // Si su mirada se cruza con un objeto con el tag "Player"
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            //print("Ha impactado" + hit.collider.tag);
            anim.SetBool("Disparar", true);
            anim.SetBool("Correr", false);
        }
        else
        {
            anim.SetBool("Disparar", false);
            anim.SetBool("Correr", true);
        }

        //Dibujamos una línea que nos muestra hacia donde mira
        Debug.DrawRay(eyesPos, Vector2.left * distancia, Color.red);
    }


}

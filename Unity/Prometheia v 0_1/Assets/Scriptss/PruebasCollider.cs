using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasCollider : MonoBehaviour
{
    //Variable de Rigid Body para poder aplicar fuerzas
    private Rigidbody2D rb2D;
    [SerializeField] float impulsoV = 4f;
    [SerializeField] float impulsoH = 4f;
    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //Empezzamos en el aire
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoverSprite();

    }

    void MoverSprite()
    {
        //Obtenemos el movimiento en horizontal, que determinará la dirección del salto
        float desplX = Input.GetAxis("Horizontal");
        //Creamos un Vector que indica hacia donde se salta, con la fuerza de la variable impulso
        Vector2 direction = new Vector2(desplX * impulsoH, impulsoV);
        //Saltamos solo si el sprite está tocando el suelo
        if (Input.GetButtonDown("Fire1") && isGrounded == true)
        {
            print("saltando" + desplX);
            //Aplicamos la fuerza según el Vector2 creado
            //Le tenemos que indicar que es un tipo de fuerza de impulso en el 2º parámetro
            rb2D.AddForce(direction, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.name == "Suelo")
        {
            print("Colisionando");
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Suelo")
        {
            print("NO Colisionando");
            isGrounded = false;
        }
    }

}

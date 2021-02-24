using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Move : MonoBehaviour
{

    //Número de arma
    [SerializeField] int arma;

    //Texto del Canvas (habría que cambiarlo por una imagen)
    [SerializeField] Text weaponText;

    //Parámetros para la animación
    bool lookingLeft;
    Animator anim;

    //Variable de Rigid Body para poder aplicar fuerzas
    private Rigidbody2D rb2D;
    [SerializeField] float speed = 3f;
    [SerializeField] float impulsoV = 4f;
    [SerializeField] float impulsoH = 4f;
    [SerializeField] bool isGrounded;

    //Booleanas para los controles
    bool jumpButton;
    bool crouchButton;
    bool weaponButton;
    bool shootButton;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        //Empezamos en el aire
        isGrounded = false;

        //Variables para la animación
        anim = GetComponent<Animator>();
        lookingLeft = false;
        anim.SetBool("Looking_L", lookingLeft);

        //Comenzamos con el arma 1
        arma = 1;
        weaponText.text = "Arma: " + arma;
        anim.SetInteger("Arma", arma);



    }

    // Update is called once per frame
    void Update()
    {
        
        //Método que realiza los movimientos del personaje
        MoveCharacter();

        //Método que cambia el arma
        WeaponChange();
    }

    void MoveCharacter()
    {
        float desplX = Input.GetAxis("Horizontal");
        anim.SetFloat("MoveHor", desplX);

        //Actualizamos el estado del detector de suelo
        anim.SetBool("Grounded", isGrounded);

        //El botón de salto y agachado depende de la plataforma
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            jumpButton = Input.GetKeyDown(KeyCode.JoystickButton17);
            crouchButton = Input.GetKey(KeyCode.JoystickButton16);
            weaponButton = Input.GetKeyDown(KeyCode.JoystickButton19);
            shootButton = Input.GetKey(KeyCode.JoystickButton14);

        }
        else
        {
            jumpButton = Input.GetKeyDown(KeyCode.JoystickButton1);
            crouchButton = Input.GetKey(KeyCode.JoystickButton0);
            weaponButton = Input.GetKeyDown(KeyCode.JoystickButton3);
            shootButton = Input.GetKey(KeyCode.JoystickButton5);

        }

        //Comprobamos si está mirando a la derecha, pero despreciando el valor 0
        if (desplX < 0)
        {
            lookingLeft = true;
        }
        else if (desplX > 0)
        {
            lookingLeft = false;
        }
        anim.SetBool("Looking_L", lookingLeft);

        //Lo movemos hacia los lados si está en el suelo y no está agachado
        Vector2 directionMove = new Vector2(desplX * speed, 0);
        if(isGrounded && !crouchButton)
        {
            rb2D.AddForce(directionMove, ForceMode2D.Impulse);
        }

        

        //Saltamos solo si el sprite está tocando el suelo
        if (jumpButton && isGrounded == true)
        {
            //Creamos un Vector que indica hacia donde se salta, con la fuerza de la variable impulso
            Vector2 directionJump = new Vector2(desplX * impulsoH, impulsoV);
            //print("saltando" + desplX);
            //Aplicamos la fuerza según el Vector2 creado
            //Le tenemos que indicar que es un tipo de fuerza de impulso en el 2º parámetro
            rb2D.AddForce(directionJump, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }

        //Agacharse
        if(crouchButton && isGrounded == true)
        {
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }
        
    }

    void WeaponChange()
    {
        if(weaponButton)
        {
            if(arma == 1)
            {
                arma = 2;
                
                
            }
            else
            {
                arma = 1;
            }
            //Cambiamos el texto y el parámetro de animator
            weaponText.text = "Arma: " + arma;
            anim.SetInteger("Arma", arma);
        }

        //Si disparamos
        anim.SetBool("Shooting", shootButton);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataformas")
        {
            //print("Colisionando");
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataformas")
        {
            //print("NO Colisionando");
            isGrounded = false;
        }
    }
}

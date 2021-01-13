using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 36f;
    private Transform theObject;
    public Vector2 hRange = Vector2.zero;
    public Vector2 vRange = Vector2.zero;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();  
    }

    void MoverNave()
    {
        moveSpeed = 6f;
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
        print(“Se está pulsando”);
        }
        if(Input.GetButtonDown(“Fire1”))
        {
        print(“Se está disparando”);
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");
        //Restringimos los limites de la pantalla
      
        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);

    }
}

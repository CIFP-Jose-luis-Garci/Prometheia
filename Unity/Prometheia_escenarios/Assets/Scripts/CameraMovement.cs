using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform Target;
    Vector3 camaraVelocity = Vector3.zero;
    [SerializeField] float smoothVelocity = 0.1f;
    

    //Variables limites
    private float leftLimit, rightLimit, topLimit, bottonLimit;

   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y + 1f, transform.position.z);     
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity,
           smoothVelocity);


        if (targetPosition.x > -10f && targetPosition.x < 97f && targetPosition.y < 4.9f)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit = 0f, rightLimit = 96.06f),
                Mathf.Clamp(transform.position.y, bottonLimit = 0f, topLimit = 0f),
                transform.position.z
            );
        }else if(targetPosition.x > 85.83f && targetPosition.x < 106.24f && targetPosition.y < 17f)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit = 96.06f, rightLimit = 96.06f),
                Mathf.Clamp(transform.position.y, bottonLimit = 0f, topLimit = 20.28f),
                transform.position.z
            );

        }else if (targetPosition.x > 85.83f && targetPosition.x < 163f && targetPosition.y > 17f)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit = 85.83f, rightLimit = 153.66f),
                Mathf.Clamp(transform.position.y, bottonLimit = 20.28f, topLimit = 20.28f),
                transform.position.z
            );

        }else if (targetPosition.x > 144.5f && targetPosition.x < 163f && targetPosition.y > 4.9f)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit = 153.66f, rightLimit = 153.66f),
                Mathf.Clamp(transform.position.y, bottonLimit = 0f, topLimit = 20.28f),
                transform.position.z
            );

        }else if (targetPosition.x > 144.5f && targetPosition.x < 240.5f && targetPosition.y < 4.9f)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit = 153.66f, rightLimit = 230.45f),
                Mathf.Clamp(transform.position.y, bottonLimit = 0f, topLimit = 0f),
                transform.position.z
            );

        }else if (targetPosition.x > 220f && targetPosition.x < 240.5f && targetPosition.y > 4.9f)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit = 230.45f, rightLimit = 230.45f),
                Mathf.Clamp(transform.position.y, bottonLimit = 0f, topLimit = 43.5f),
                transform.position.z
            );

        }













    }
}

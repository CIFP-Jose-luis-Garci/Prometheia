using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 2, -10);

    }
}

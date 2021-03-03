using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPartida : MonoBehaviour
{
    private bool continuar = false;

    public void setContinuar()
    {
        continuar = true;
    }

    public bool getContinuar()
    {
        return continuar;
    }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void destruir()
    {
        Destroy(gameObject);
    }

}

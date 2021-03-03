using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    DatabaseController databaseController;
    private Transform character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character").GetComponent<Transform>();
        databaseController = GameObject.Find("DatabaseController").GetComponent<DatabaseController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            databaseController.escribirPartida(character.position);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

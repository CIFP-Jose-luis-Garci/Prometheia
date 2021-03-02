using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Transform character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterP = new Vector3(character.position.x, character.position.y + 3.5f, transform.position.z);

        if (characterP.x > 127f)
        {
            //Save the current Game as a new saved Game
            SaveLoad.Save();
            //Move on to game...
            Application.LoadLevel(1);
        }

        if (characterP.x > 228f && characterP.y > 40.59f)
        {
            //Save the current Game as a new saved Game
            SaveLoad.Save();
            //Move on to game...
            Application.LoadLevel(1);
        }
    }
}

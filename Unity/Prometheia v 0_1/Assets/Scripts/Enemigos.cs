using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{

    public Transform[] enemiesPos = new Transform[4];
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform enemy in enemiesPos)
        {
            //print(enemy.position);
            Instantiate(enemyPrefab, enemy.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

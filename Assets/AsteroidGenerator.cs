using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidGenerator : MonoBehaviour
{
    public GameObject[] asteroidList;
    public GameObject Player;
    void Start()
    {
        spawnAsteroids(500);
    }

    
    void Update()
    {
        
    }

    void spawnAsteroids(int amount)
    {
       
        for (int i = 0; i < amount; i++)
        {
            var playerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

            var x = Random.Range(playerPos.x - 5000, playerPos.x + 5000);
            var y = Random.Range(playerPos.y - 5000, playerPos.x + 5000);
            var z = Random.Range(playerPos.z - 5000, playerPos.z + 5000);

            var asteroidPos = new Vector3(x,y,z);

            Instantiate(asteroidList[Random.Range(0,3)], asteroidPos, Quaternion.identity);
        }
    }
}

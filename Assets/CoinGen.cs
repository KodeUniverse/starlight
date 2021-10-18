using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGen : MonoBehaviour
{

    [SerializeField] GameObject coin;
    [SerializeField] int total_coins = 0;
    public GameObject Player;
    
    void Start()
    {
        spawnCoins(100);
    }

    void spawnCoins(int amount)
    {
        Vector3 player_pos = Player.transform.position;
        float offset = 500f;
        

        for(int i = 0; i < amount; i++)
        {
            float x = Random.Range(player_pos.x - offset, player_pos.x + offset);
            float y = Random.Range(player_pos.y - offset, player_pos.y + offset);
            float z = Random.Range(player_pos.z - offset, player_pos.z + offset);
            Vector3 coin_pos = new Vector3(x, y, z);

            Instantiate(coin, coin_pos, Quaternion.identity);
            coin.transform.gameObject.tag = "Coin";
            total_coins++;
        }
    }
}

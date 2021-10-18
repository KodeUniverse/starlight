using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    
    public Text score_string;
    
    public int score = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            score += 1;
            score_string.text = "Score: " + score.ToString();
        }

    }
    

}

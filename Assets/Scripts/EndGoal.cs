using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{ 
    public Player player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && player.score >= 10)
        {
            collision.GetComponent<Player>().Win();
        }
        else
        {
            Debug.Log("Need 10 coins");
        }
    }
}

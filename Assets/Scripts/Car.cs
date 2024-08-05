using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float speed;
    public Vector3 startPos;
    public Vector3 endPos;

    private void Update()
    {
        // Changes the position of the car to transform.position to endPos, using the Speed Variable
        // Dont use startPos instead of transform.position, it bugss 
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        // Loops the car moving if it hits the end.
        if(transform.position == endPos)
        {
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GameOver();
           
        }
    }

}

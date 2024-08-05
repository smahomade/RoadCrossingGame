using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public int edgeDistance;
    private Vector3 targetPos;
    public int score;


    private void Start()
    {
        edgeDistance = 2; // Must be defaulted at 2 tiles to clamp camera left and right
        targetPos = transform.position;
    }


    public void Move (Vector3 moveDirection)
    {
        //Applies a Clamp on the x axis, between 2 <= x >= -2, (CANNOT HIT 3 OR -3)
        //Mathf.Abs keeps it as a positive integer
        Debug.Log("Movie Direction: " + moveDirection);
        if (Mathf.Abs(targetPos.x + moveDirection.x)  > edgeDistance)
        {
            Debug.Log("g " + Mathf.Abs(targetPos.x + moveDirection.x));
            return;
        }
        targetPos += moveDirection;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void AddScore (int amount)
    {
        score += amount;
        UI.instace.UpdateScoreText(score);
    }

    public void GameOver()
    {
        UI.instace.SetEndScreen(false);
    }

    public void Win()
    {
        UI.instace.SetEndScreen(true);
    }


}

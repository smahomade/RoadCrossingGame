
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetection : MonoBehaviour
{

    public Player player;
    private Vector2 startPos;
    public int pixelDistToDetect = 20;
    private bool fingerDown;
    public float moveUp;
    public float moveSide;

    private void Update()
    {
        HandleTouchInput(); 
        HandleMouseInput();
        HandleKeyboardInput();
    }


    private void HandleTouchInput()
    {
        if(!fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        // is our finger touching the screen?
        if (fingerDown && Input.touchCount > 0)
        {
            // did we swipe up?
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {

                fingerDown = false;
                player.Move(Vector3.up);
                Debug.Log("Swipe up");
            }
            else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.left);
                Debug.Log("Swipe left");
            }
            else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.right);
                Debug.Log("Swipe right");
            }
            if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                fingerDown = false;
            }
        }

    }
    
    private void HandleMouseInput()
    {
        // Controls - Swipping Using Mouse 
        if (!fingerDown && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }


        if (fingerDown)
        {
            if (Input.mousePosition.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.up);
                Debug.Log("Swipe up");
            }
            else if (Input.mousePosition.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.left);
                Debug.Log("Swipe left");
            }
            else if (Input.mousePosition.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                player.Move(Vector3.right);
                Debug.Log("Swipe right");
            }
            if (fingerDown && Input.GetMouseButtonUp(0))
            {
                fingerDown = false;
            }
        }
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.D)) { player.Move(Vector3.right); }
        if (Input.GetKeyDown(KeyCode.W)) { player.Move(Vector3.up); }
        if (Input.GetKeyDown(KeyCode.A)) { player.Move(Vector3.left); }
    }




}

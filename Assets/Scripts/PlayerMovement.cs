using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float sideSpeed;
    public GameManager gameManager;
   

    static public bool TopDown;
    static public bool LeftRight;
    static public int dirTopDown;
    static public int dirLeftRight;


    private bool spawned = false;
    private float decay;

    void Start()
    {
        dirTopDown = 1;
        dirLeftRight = 1;
        TopDown = true;
        LeftRight = false;


    }
    void FixedUpdate()
    {
        if (rb.position.y < -1f)
        {
            
            gameManager.GameOver();

        }
        if(Input.GetKey("r"))
        {
            FindObjectOfType<GameManager>().restartDelay = 0.1f;
            gameManager.GameOver();
        }
      
        if (TopDown)
        {
            
            rb.AddForce(0, 0, speed * Time.deltaTime * dirTopDown);
            if (Input.GetKey("a"))
            {
                rb.AddForce(-sideSpeed * Time.deltaTime * dirTopDown, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(sideSpeed * Time.deltaTime * dirTopDown, 0, 0, ForceMode.VelocityChange);
            }
        }
        if (LeftRight)
        {
            rb.AddForce(speed * Time.deltaTime * dirLeftRight, 0, 0);
            if (Input.GetKey("a"))
            {
                rb.AddForce(0, 0, sideSpeed * Time.deltaTime * dirLeftRight, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(0, 0, -sideSpeed * Time.deltaTime * dirLeftRight, ForceMode.VelocityChange);
            }
        }

        Reset();
        if (Input.GetKey("q") && !spawned)
        {
            decay = 0.3f;
            spawned = true;
            if (TopDown)
            {
                TopDown = false;
                LeftRight = true;
            }
            else
            {
                TopDown = true;
                LeftRight = false;
            }
            ChangeDirectionQ();

        }
        if (Input.GetKey("e") && !spawned)
        {
            decay = 0.3f;
            spawned = true;
            if (TopDown)
            {
                TopDown = false;
                LeftRight = true;
            }
            else
            {
                TopDown = true;
                LeftRight = false;
            }
            ChangeDirectionE();

        }

    }
    private void ChangeDirectionE()
    {

        if (TopDown)
        {
            if (dirLeftRight == 1)
            {
                dirLeftRight = -1;
            }
            else
            {
                dirLeftRight = 1;
            }
        }
        if (LeftRight)
        {
            if (dirTopDown == 1)
            {
                dirTopDown = -1;
            }
            else
            {
                dirTopDown = 1;
            }
        }
    }
    private void ChangeDirectionQ()
    {
        if (TopDown)
        {
            if (dirTopDown == 1)
            {
                dirTopDown = -1;
            }
            else
            {
                dirTopDown = 1;
            }
        }
        if (LeftRight)
        {
            if (dirLeftRight == 1)
            {
                dirLeftRight = -1;
            }
            else
            {
                dirLeftRight = 1;
            }
        }
    }
    private void Reset()
    {
        if (spawned && decay > 0)
        {
            decay -= Time.deltaTime;
        }
        if (decay < 0)
        {
            decay = 0;
            spawned = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTrigger : MonoBehaviour
{
    public PlayerMovement movement;
    static public float addForceSpeed;
    void OnTriggerEnter()
    {
        if (PlayerMovement.TopDown)
        {
            movement.rb.AddForce(0, 0, addForceSpeed * PlayerMovement.dirTopDown);
        }
        if (PlayerMovement.LeftRight)
        {
            movement.rb.AddForce(addForceSpeed * PlayerMovement.dirLeftRight, 0, 0);
        }
    }
}

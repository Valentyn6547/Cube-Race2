using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public PlayerMovement movement;
 

    void OnCollisionEnter(Collision collisionHit)
    {
        if (collisionHit.collider.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    

    }

   
   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour
{
    public GameObject player;
    public Vector3 offcet;
    public Vector3 offcet2;
    public float camSpeed;

    void Start()
    {
        transform.position = player.transform.position - offcet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerMovement.TopDown)
        {
            if (PlayerMovement.dirTopDown > 0)
            {
                Vector3 newCamPos = player.transform.position - offcet;
                transform.position = Vector3.Lerp(transform.position, newCamPos, camSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 newCamPos = player.transform.position + new Vector3(offcet.x, offcet.y * (-1), offcet.z);
                transform.position = Vector3.Lerp(transform.position, newCamPos, camSpeed * Time.deltaTime);

            }

        }

        if (PlayerMovement.LeftRight)
        {
            if (PlayerMovement.dirLeftRight > 0)
            {
                Vector3 newCamPos = player.transform.position - offcet2;
                transform.position = Vector3.Lerp(transform.position, newCamPos, camSpeed * Time.deltaTime);

            }
            else
            {
                Vector3 newCamPos = player.transform.position + new Vector3(offcet2.x, offcet2.y * (-1), offcet2.z);
                transform.position = Vector3.Lerp(transform.position, newCamPos, camSpeed * Time.deltaTime);

            }

        }
        Vector3 direction = player.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

    }
}

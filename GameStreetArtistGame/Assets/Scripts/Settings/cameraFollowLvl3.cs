using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowLvl3 : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offsetX; // Offset no eixo X
    public Vector3 offsetY; // Offset no eixo Y
    private bool followY = false; // Variável para controlar o seguimento no eixo Y

    private void LateUpdate()
    {
        Vector3 desiredPosition;
        
        if (followY)
        {
            desiredPosition = new Vector3(target.position.x + offsetX.x, target.position.y + offsetY.y, transform.position.z);
        }
        else
        {
            desiredPosition = new Vector3(target.position.x + offsetX.x, transform.position.y, transform.position.z);
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void EnableFollowY()
    {
        followY = true;
    }

    public void NoFollowY()
    {
        followY = false;
    }   
}
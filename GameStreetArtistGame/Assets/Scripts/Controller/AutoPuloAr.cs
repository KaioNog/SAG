using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPuloAr : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SkateController skateController = other.GetComponent<SkateController>();
            
            if (skateController != null)
            {
                skateController.AutoJumpAir();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class shoveitController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SkateController skateController = other.GetComponent<SkateController>();
            
            if (skateController != null)
            {
                FindObjectOfType<AudioManager>().Play("Coletavel");       
                skateController.ShoveIt();
                Destroy(gameObject);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class scoreController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerData.playerDataInstance.AddScore(m:10);
            FindObjectOfType<AudioManager>().Play("Dinheiro"); 
            Destroy(this.gameObject);
        }
    }
}

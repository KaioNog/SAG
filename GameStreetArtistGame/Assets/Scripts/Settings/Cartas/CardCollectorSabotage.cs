using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CardCollectorSabotage : MonoBehaviour
{
    public void CollectSabotageCard()
    {
        ProgressManager.sabotageCardCollected = true;
        PlayerPrefs.SetInt("SabotageCard", 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Carta");
            CollectSabotageCard();
            Debug.Log("Carta Sabotage");
            Destroy(this.gameObject);
        }
    }
}
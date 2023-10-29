using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CardCollectorMH2O : MonoBehaviour
{
    public void CollectMH2OCard()
    {
        ProgressManager.mh2oCardCollected = true;
        PlayerPrefs.SetInt("MH2OCard", 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Carta");
            CollectMH2OCard();
            Debug.Log("Carta Sabotage");
            Destroy(this.gameObject);
        }
    }
}
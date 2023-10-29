using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CardCollectorRacionais : MonoBehaviour
{
    public void CollectRacionaisCard()
    {
        ProgressManager.racionaisCardCollected = true;
        PlayerPrefs.SetInt("RacionaisCard", 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Carta");
            CollectRacionaisCard();
            Debug.Log("Carta Sabotage");
            Destroy(this.gameObject);
        }
    }
}
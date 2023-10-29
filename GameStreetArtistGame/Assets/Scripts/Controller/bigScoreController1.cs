using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigScoreController1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerData.playerDataInstance.AddScore(m:30);
            Debug.Log("Coletou money");
            Destroy(this.gameObject);
        }
    }
}

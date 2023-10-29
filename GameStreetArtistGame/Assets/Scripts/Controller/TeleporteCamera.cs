using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleporteCamera : MonoBehaviour
{
    public Animator portalAnimatorUi; // Referência ao componente Animator
    public GameObject portalActivePainel; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Obter o componente da câmera e ativar o seguimento no eixo Y
            cameraFollowLvl3 cameraScript = Camera.main.GetComponent<cameraFollowLvl3>();
            if (cameraScript != null)
            {
                cameraScript.EnableFollowY();
            }
            
            FindObjectOfType<AudioManager>().Play("Portal");       
            Vector2 newPosition = collision.transform.position;
            newPosition.x += 25f;
            collision.transform.position = newPosition;
            portalActivePainel.SetActive(true);
            portalAnimatorUi.SetTrigger("activatePortalUi");
            Invoke("DesativarTrigger", 1f);
        }
    }

    void DesativarTrigger()
    {
        portalAnimatorUi.ResetTrigger("activatePortalUi");
        portalActivePainel.SetActive(false);
    }
}

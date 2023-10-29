using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class flipController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SkateController skateController = other.GetComponent<SkateController>();

            /*
            SkateController é o nome do script que você criou para controlar o comportamento do jogador.

            skateController é a variável local que você está declarando no escopo do método para armazenar a referência ao componente SkateController do jogador.

            other.GetComponent<SkateController>() é uma chamada de método que está sendo usada para acessar o componente SkateController anexado ao objeto que colidiu com o trigger. Essa chamada de método retorna o componente SkateController, que você está atribuindo à variável skateController.
            */
            
            if (skateController != null)
            {
                FindObjectOfType<AudioManager>().Play("Coletavel"); 
                skateController.Flip();
                Destroy(gameObject);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject sabotageButton;
    public GameObject racionaisButton;
    public GameObject mh2oButton;

    void Start()
    {
        // Desative os botões das cartas no início do jogo
        sabotageButton.SetActive(false);
        racionaisButton.SetActive(false);
        mh2oButton.SetActive(false);

        // Verifique as cartas coletadas e ative os botões apropriados
        if (ProgressManager.sabotageCardCollected)
        {
            sabotageButton.SetActive(true);
        }

        if (ProgressManager.racionaisCardCollected)
        {
            racionaisButton.SetActive(true);
        }

        if (ProgressManager.mh2oCardCollected)
        {
            mh2oButton.SetActive(true);
        }
    }
}
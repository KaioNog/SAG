using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static bool sabotageCardCollected = false;
    public static bool racionaisCardCollected = false;
    public static bool mh2oCardCollected = false;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        LoadProgress();
    }

    public static void ResetProgress()
    {
        sabotageCardCollected = false;
        racionaisCardCollected = false;
        mh2oCardCollected = false;
        SaveProgress();
    }

    public static void SaveProgress()
    {
        PlayerPrefs.SetInt("SabotageCard", sabotageCardCollected ? 1 : 0);
        PlayerPrefs.SetInt("RacionaisCard", racionaisCardCollected ? 1 : 0);
        PlayerPrefs.SetInt("MH2OCard", mh2oCardCollected ? 1 : 0);
    }

    public static void LoadProgress()
    {
        sabotageCardCollected = PlayerPrefs.GetInt("SabotageCard", 0) == 1;
        racionaisCardCollected = PlayerPrefs.GetInt("RacionaisCard", 0) == 1;
        mh2oCardCollected = PlayerPrefs.GetInt("MH2OCard", 0) == 1;
    }

    void OnApplicationQuit()
    {
        ProgressManager.ResetProgress();
    }
}
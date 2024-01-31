using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;


    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.VICTORY_CONDITION)
        {
            victoryPanel.SetActive(true);
            defeatPanel.SetActive(false);
        }
        else
        {
            victoryPanel.SetActive(false);
            defeatPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

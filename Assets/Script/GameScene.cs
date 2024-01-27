using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ControlsPanel;
    void Start()
    {
        ControlPanel();
       

    }
    void ControlPanel()
    {
        if (ControlsPanel != null)
        {
            ControlsPanel.SetActive(true);
            Time.timeScale = 0;
        }
       
    }
   public void ControlPanelOff()
    {
        ControlsPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
}

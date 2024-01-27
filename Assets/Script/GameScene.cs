using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ControlsPanel;
    public GameObject contractGame; 
    void Start()
    {
        ControlPanel();
       

    }
    private void Update()
    {
      
       

    }
    void ControlPanel()
    {
        if (ControlsPanel != null)
        {
            ControlsPanel.SetActive(true);
            Time.timeScale = 0;
        }
       
    }
 
    public void ContractOff()
    {
        contractGame.SetActive(false); 
        Time.timeScale = 1;

    }
   public void ControlPanelOff()
    {
        ControlsPanel.SetActive(false);
        contractGame.SetActive(true); 
        Time.timeScale = 0;
    }

    
}

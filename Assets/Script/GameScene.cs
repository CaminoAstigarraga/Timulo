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
        if (Input.GetMouseButtonDown(0))
        {
            contractGame.SetActive(true);
            Time.timeScale = 0; 
        }
        if (Input.GetMouseButtonDown(1))
        {
            contractGame.SetActive(false);
            Time.timeScale = 1; 
        }

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

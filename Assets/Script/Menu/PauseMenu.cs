using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeReference] GameObject pauseMenu;

    // Llamado cuando pausamos el juego
    public void Update()
    {
       
        {
            if (Input.GetKey(KeyCode.Mouse2))
            {
                Pause(); 
            } 
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    // Llamado cuando reanudamos el juego
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Llamado cuando salímos del juego al menú principal
    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1;

    }
}

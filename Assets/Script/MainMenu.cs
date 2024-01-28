using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource MenuAudios;


    public AudioClip[] audios; 


    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }




    public void StartGame()
    {
        Startercorrutine(Startercorrutine()); 

    }
    IEnumerator Startercorrutine()
    {
        MenuAudios.clip = audios[0];

        MenuAudios.Play();
        yield return new WaitForSeconds(5);
SceneManager.LoadScene("GameScene");

    }
   

    public void Exit()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public void Awake()
    {
        // Comprobamos que la instancia del GameManager exista, de no ser así, definimos éste como la instancia actual
        // Si la instancia ya existe y no es la de este gameObject, destruímos este.
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // nos aseguramos de nos destruirlo al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(){
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}

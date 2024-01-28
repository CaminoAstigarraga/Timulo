using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public AudioClip[] Effects;
    private AudioSource reproductor;


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
    public void Start()
    {

      
    

    }
 
    
    // Update is called once per frame
    void Update()
    {
   
    }


}
    

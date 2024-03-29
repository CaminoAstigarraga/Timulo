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

    public static bool VICTORY_CONDITION = false;

    // Posiciones en las que se estacionan o a las que se dirigen los npc
    public static Vector3 SPAWNPOINT_0 = new Vector3(-14.0f, -1.51f, 0.0f);
    public static Vector3 SPAWNPOINT_1 = new Vector3(-11.0f, -1.51f, 0.0f);
    public static Vector3 SPAWNPOINT_2 = new Vector3(-7.0f, -1.51f, 0.0f);
    public static Vector3 SPAWNPOINT_3 = new Vector3(-3.0f, -1.51f, 0.0f);
    public static Vector3 SPAWNPOINT_4 = new Vector3(1.0f, -1.51f, 0.0f);

    public static GameManager Instance { get; private set; }

    
    public void Awake()
    {
        // Comprobamos que la instancia del GameManager exista, de no ser as�, definimos �ste como la instancia actual
        // Si la instancia ya existe y no es la de este gameObject, destru�mos este.
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
    

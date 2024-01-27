using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public NpcSpawner npcSpawner;

    private bool lockInput;
    // Tiempo que se quita el control al jugador mientras la cola avanza
    private float lockInputTime = 1.0f;
    // Contador para cuando la cola comienza a avanzar
    private float currentLockInputTime;

    private float currentCapacity;
    private float maxCapacity = 100.0f;

    public Image barFiller;

    // Modificadores de penalizadores, bonificadores y velocidad de la barra de aforo
    private float[] fillSpeed = { 7.69f, 9.1f, 11.11f, 14.28f, 16.66f, 33.33f };
    private float[] bonus = { 0.13f, 0.11f, 0.08f, 0.07f, 0.06f, 0.05f };
    private float[] pena = { 0.14f, 0.16f, 0.18f, 0.20f, 0.21f, 0.25f };

    // Entero que cambia cada 30 segundos para moverse por los arrays de la barra de aforo;
    public int timerValues = 0;


    // Start is called before the first frame update
    void Start()
    {
        lockInput = true;
        currentLockInputTime = 0;
      
        currentCapacity = 0;

    }

    // Update is called once per frame
    void Update()
    {

        // Comprobamos si el jugador puede interactuar
        if (!lockInput)
        {
            currentLockInputTime = 0.0f;
            if (Input.GetMouseButtonDown(0))
            {
                lockInput = true;
                Debug.Log("Pressed left-click.");
                // Deja pasar al npc
                npcSpawner.removeFromQueue(0);
                currentCapacity -= bonus[timerValues] * 100;
            }

            else if (Input.GetMouseButtonDown(1))
            {
                lockInput = true;
                Debug.Log("Pressed right-click.");
                // Obliga al Npc a volver
                npcSpawner.removeFromQueue(1);
                currentCapacity += pena[timerValues] * 100;
            }

            //if (Input.GetMouseButtonDown(2)) Debug.Log("Pressed middle-click.");
        }
        else
        {
            currentLockInputTime += Time.deltaTime;
            if (currentLockInputTime >= lockInputTime)
            {
                lockInput = false;
                currentLockInputTime = 0;
            }
        }

        // Rellenamos la barra de aforo progresivamente según pasa el tiempo. Se podría alterar la velocidad conforme avance el tiempo
        currentCapacity += Time.deltaTime * fillSpeed[timerValues];
        barFiller.fillAmount = (float) currentCapacity / (float) maxCapacity;

        if(barFiller.fillAmount == 1)
        {
            SceneManager.LoadScene("GameOver");
        }
       
      
    }

    public void increaseSpeed()
    {
        timerValues++;
    }
}

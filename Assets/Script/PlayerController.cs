using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private float fillSpeed;


    // Start is called before the first frame update
    void Start()
    {
        lockInput = true;
        currentLockInputTime = 0;

        currentCapacity = 0;
        fillSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {

        // Comprobamos si el jugador puede interactu
        if (!lockInput)
        {
            currentLockInputTime = 0.0f;
            if (Input.GetMouseButtonDown(0))
            {
                lockInput = true;
                Debug.Log("Pressed left-click.");
                npcSpawner.removeFromQueue();
            }

            else if (Input.GetMouseButtonDown(1))
            {
                lockInput = true;
                Debug.Log("Pressed right-click.");
                npcSpawner.removeFromQueue();
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
        currentCapacity += Time.deltaTime * fillSpeed;
        barFiller.fillAmount = (float) currentCapacity / (float) maxCapacity;

        if(barFiller.fillAmount == 1)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

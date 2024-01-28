using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public NpcSpawner npcSpawner;

    public List<GameObject> prohibitionPanels;

    public Alicia alicia;

    private bool lockInput;
    // Tiempo que se quita el control al jugador mientras la cola avanza
    private float lockInputTime = 1.0f;
    // Contador para cuando la cola comienza a avanzar
    private float currentLockInputTime;

    private float currentCapacity;
    private float maxCapacity = 100.0f;

    public Image barFiller;

    public GameObject greenLight;

    // Modificadores de penalizadores, bonificadores y velocidad de la barra de aforo
    private float[] fillSpeed = { 7.69f, 9.1f, 11.11f, 14.28f, 16.66f, 33.33f };
    private float[] bonus = { 0.13f, 0.11f, 0.08f, 0.07f, 0.06f, 0.05f };
    private float[] pena = { 0.14f, 0.16f, 0.18f, 0.20f, 0.21f, 0.25f };

    // Entero que cambia cada 30 segundos para moverse por los arrays de la barra de aforo;
    private int timerValues = -1;

    private List<int[]> activeProhibitions;

    // Start is called before the first frame update
    void Start()
    {
        lockInput = true;
        currentLockInputTime = 0.9f;
      
        currentCapacity = 0;

        activeProhibitions = new List<int[]>();

    }

    // Update is called once per frame
    void Update()
    {

        // Comprobamos si el jugador puede interactuar
        if (!lockInput)
        {
            greenLight.GetComponent<SpriteRenderer>().color = Color.white;
            currentLockInputTime = 0.0f;
            if (Input.GetMouseButtonDown(0))
            {
                checkProhibitions(npcSpawner.GetComponent<NpcSpawner>().getCurrentInQueue(), true);
                lockInput = true;
                // Deja pasar al npc
                npcSpawner.removeFromQueue(0);

                StartCoroutine(alicia.GetComponent<Alicia>().AliciaYes());
                
            }

            else if (Input.GetMouseButtonDown(1))
            {
                checkProhibitions(npcSpawner.GetComponent<NpcSpawner>().getCurrentInQueue(), false);
                lockInput = true;
                // Obliga al Npc a volver
                npcSpawner.removeFromQueue(1);

                StartCoroutine(alicia.GetComponent<Alicia>().AliciaNo());
            }

            //if (Input.GetMouseButtonDown(2)) Debug.Log("Pressed middle-click.");
        }
        else
        {
            greenLight.GetComponent<SpriteRenderer>().color = Color.red;
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

    private void checkProhibitions(GameObject currentInQueue, bool pass)
    {
        foreach(int[] p in activeProhibitions)
        {
            if ((int) char.GetNumericValue(currentInQueue.name[p[0]]) == p[1])
            {
                if (pass)
                {
                    currentCapacity += pena[timerValues] * 100;
                }
                else
                {
                    currentCapacity -= bonus[timerValues] * 100;
                }
                return;
            }   
        }
        if(pass)
            currentCapacity -= bonus[timerValues] * 100;
        else
            currentCapacity += pena[timerValues] * 100;
    }

    public void increaseSpeed()
    {
        timerValues++;
    }

    public void addProhibition()
    {
        int position;
        int value;

        position = Random.Range(0, 4);
        switch (position)
        {
            case 0:
                value = Random.Range(0, 4);
                break;
            case 1:
                value = Random.Range(0, 5);
                break;
            case 2:
                value = Random.Range(0, 4);
                break;
            case 3:
                value = Random.Range(0, 2);
                break;
            default:
                value = 0; 
                break;
        }
        int[] prohibition = new int[] { position, value };
        Debug.Log(position +"" + value);
        foreach (int[] item in activeProhibitions)
        {
            if (prohibition == item)
            {
                addProhibition();
                break;
            }
        }
        prohibitionPanels[0].SetActive(true);
        activeProhibitions.Add(prohibition);
    }
}

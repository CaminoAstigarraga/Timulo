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
    private float[] fillSpeed = { 7.69f, 9.1f, 11.11f, 14.28f, 16.66f, 25.0f };
    private float[] bonus = { 0.15f, 0.15f, 0.16f, 0.20f, 0.20f, 0.28f };
    private float[] pena = { 0.1f, 0.1f, 0.1f, 0.15f, 0.18f, 0.22f };

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
            GameManager.VICTORY_CONDITION = false;
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
                if (currentCapacity < 0)
                    currentCapacity = 0.0f;
                return;
            }   
        }
        if(pass)
            currentCapacity -= bonus[timerValues] * 100;
        else
            currentCapacity += pena[timerValues] * 100;
        if (currentCapacity < 0)
            currentCapacity = 0.0f;
    }

    public void increaseSpeed()
    {
        timerValues++;
    }

    public void addProhibition(int currentProhibition)
    {
        int position = 0;
        int value = 0;

        switch (currentProhibition)
        {
                // card type
            case 0:
                position = 1;
                value = Random.Range(0, 5);
                break;
                // hat type
            case 1:
                position = 2;
                value = Random.Range(1, 4);
                break;
                // creature type
            case 2:
                position = 0;
                value = Random.Range(1, 4);
                break;
                // sunglasses
            case 3:
                position = 3;
                value = 1;
                break;
            // hat type again
            case 4:
                position = 2;
                value = Random.Range(1, 4);
                break;
            // creature type again (including cards)
            default:
                position = 0;
                value = Random.Range(0, 4);
                break;
        }
        int[] prohibition = new int[] { position, value };
        foreach (int[] item in activeProhibitions)
        {
            if (prohibition == item)
            {
                addProhibition(currentProhibition);
                return;
            }
        }
        prohibitionPanels[currentProhibition].SetActive(true);
        prohibitionPanels[currentProhibition].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/Prohibition" + position + value);
        activeProhibitions.Add(prohibition);
        // old code
        /*int position;
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
                value = Random.Range(1, 4);
                break;
            case 3:
                value = 1;
                break;
            default:
                value = 0; 
                break;
        }
        int[] prohibition = new int[] { position, value };
        foreach (int[] item in activeProhibitions)
        {
            if (prohibition == item)
            {
                addProhibition(currentProhibition);
                break;
            }
        }
        prohibitionPanels[currentProhibition].SetActive(true);
        prohibitionPanels[currentProhibition].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/Prohibition" + position + value);
        activeProhibitions.Add(prohibition);*/
    }
}

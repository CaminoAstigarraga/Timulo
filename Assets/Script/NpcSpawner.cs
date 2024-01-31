using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    
    //Referencia al controlador del jugador
    public GameObject playerController;

    private List<GameObject> queue;
    
    private string generateRandomCharacter()
    {
        string id = "";

        //type
        id += Random.Range(0, 4);

        //deck
        if(id.Equals("0"))
            id += Random.Range(0, 5);
        else
            id += 0;

        //hat
        id += Random.Range(0, 4);

        // glasses
        id += Random.Range(0, 2);

        return id;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos la lista de los 4 npcs,
        queue = new List<GameObject>();
        queue.Add(spawnNpc(GameManager.SPAWNPOINT_0, GameManager.SPAWNPOINT_1, 1));
        queue.Add(spawnNpc(GameManager.SPAWNPOINT_1, GameManager.SPAWNPOINT_2, 2));
        queue.Add(spawnNpc(GameManager.SPAWNPOINT_2, GameManager.SPAWNPOINT_3, 3));
        queue.Add(spawnNpc(GameManager.SPAWNPOINT_3, GameManager.SPAWNPOINT_4, 4));

    }

    // Creamos un npc, le pasamos su ubicación inicial, 
    private GameObject spawnNpc(Vector3 spawnPoint, Vector3 target, int layerPos)
    {
        string filename = "Prefabs/" + generateRandomCharacter();
        GameObject newNpc = Instantiate((GameObject)Resources.Load(filename), spawnPoint, Quaternion.identity);
        newNpc.GetComponent<FABRICIANPC>().setInitialPosition(spawnPoint, target);
        newNpc.GetComponent<SpriteRenderer>().sortingOrder = layerPos;
        return newNpc;
    }


    public void removeFromQueue(int dir)
    {
        GameObject aux = queue[3];
        for (int i = 3; i > 0; i--)
        {
            queue[i] = queue[i-1];
            aux.GetComponent<FABRICIANPC>().setDestination(dir);
        }
        updateNpcPosition();
        queue[0] = spawnNpc(GameManager.SPAWNPOINT_0, GameManager.SPAWNPOINT_1, 1);
    }

    private void updateNpcPosition()
    {
        queue[1].GetComponent<FABRICIANPC>().updateTarget(GameManager.SPAWNPOINT_2);
        queue[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
        queue[2].GetComponent<FABRICIANPC>().updateTarget(GameManager.SPAWNPOINT_3);
        queue[2].GetComponent<SpriteRenderer>().sortingOrder = 3;
        queue[3].GetComponent<FABRICIANPC>().updateTarget(GameManager.SPAWNPOINT_4);
        queue[3].GetComponent<SpriteRenderer>().sortingOrder = 4;

    }

    public GameObject getCurrentInQueue()
    {
        return queue[3];
    }
}

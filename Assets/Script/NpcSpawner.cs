using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    
    //Referencia al controlador del jugador
    public GameObject playerController;

    private List<GameObject> queue;

    // Posiciones en las que se estacionan o a las que se dirigen los npc
    private Vector3 SpawnPoint0 = new Vector3(-14.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint1 = new Vector3(-11.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint2 = new Vector3(-7.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint3 = new Vector3(-3.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint4 = new Vector3(1.0f, -1.51f, 0.0f);
    
    private string generateRandomCharacter()
    {
        string id = "000";

        //type


        // glasses
        
        return id + Random.Range(0, 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        // Inicializamos la lista de los 4 npcs,
        queue = new List<GameObject>();

        string aux = "Prefabs/" + generateRandomCharacter();
        GameObject firstNpc = Instantiate((GameObject)Resources.Load(aux), SpawnPoint1, Quaternion.identity);
        queue.Add(firstNpc);
        firstNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint0, SpawnPoint1);

        aux = "Prefabs/" + generateRandomCharacter();
        GameObject secondNpc = Instantiate((GameObject)Resources.Load(aux), SpawnPoint2, Quaternion.identity);
        queue.Add(secondNpc);
        secondNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint1, SpawnPoint2);

        aux = "Prefabs/" + generateRandomCharacter();
        GameObject thirdNpc = Instantiate((GameObject)Resources.Load(aux), SpawnPoint3, Quaternion.identity);
        queue.Add(thirdNpc);
        thirdNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint2, SpawnPoint3);

        aux = "Prefabs/" + generateRandomCharacter();
        GameObject fourthNpc = Instantiate((GameObject)Resources.Load(aux), SpawnPoint4, Quaternion.identity);
        queue.Add(fourthNpc);
        fourthNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint3, SpawnPoint4);
        
    }

    // Creamos un npc, le pasamos su ubicación inicial, 
    void spawnNpc()
    {
        string aux = "Prefabs/" + generateRandomCharacter();
        GameObject newNpc = Instantiate((GameObject)Resources.Load(aux), SpawnPoint0, Quaternion.identity);
        queue[0] = newNpc;
        newNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint0, SpawnPoint1);
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
        spawnNpc();
    }

    private void updateNpcPosition()
    {

        queue[1].GetComponent<FABRICIANPC>().updateTarget(SpawnPoint2);
        queue[2].GetComponent<FABRICIANPC>().updateTarget(SpawnPoint3);
        queue[3].GetComponent<FABRICIANPC>().updateTarget(SpawnPoint4);

    }

    public GameObject getCurrentInQueue()
    {
        return queue[3];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    
    //Referencia al controlador del jugador
    public GameObject playerController;

    public GameObject plantillaFabriciaNpc;

    List<GameObject> queue;

    // Posiciones en las que se estacionan o a las que se dirigen los npc
    private Vector3 SpawnPoint0 = new Vector3(-14.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint1 = new Vector3(-11.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint2 = new Vector3(-7.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint3 = new Vector3(-3.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint4 = new Vector3(1.0f, -1.51f, 0.0f);
    
    private string generateRandomCharacter()
    {
        string id = "000";
        // glasses
        
        return id + Random.Range(0, 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        // Inicializamos la lista de los 4 npcs,
        queue = new List<GameObject>();

        
        GameObject firstNpc = Instantiate((GameObject)Resources.Load("prefabs/" + generateRandomCharacter()), SpawnPoint1, Quaternion.identity);
        queue.Add(firstNpc);
        firstNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint0, SpawnPoint1);

        GameObject secondNpc = Instantiate((GameObject)Resources.Load("prefabs/" + generateRandomCharacter()), SpawnPoint2, Quaternion.identity);
        queue.Add(secondNpc);
        secondNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint1, SpawnPoint2);

        GameObject thirdNpc = Instantiate((GameObject)Resources.Load("prefabs/" + generateRandomCharacter()), SpawnPoint3, Quaternion.identity);
        queue.Add(thirdNpc);
        thirdNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint2, SpawnPoint3);

        GameObject fourthNpc = Instantiate((GameObject)Resources.Load("prefabs/" + generateRandomCharacter()), SpawnPoint4, Quaternion.identity);
        queue.Add(fourthNpc);
        fourthNpc.GetComponent<FABRICIANPC>().setInitialPosition(SpawnPoint3, SpawnPoint4);

        
    }

    // Creamos un npc, le pasamos su ubicación inicial, 
    void spawnNpc()
    {
        GameObject newNpc = Instantiate(plantillaFabriciaNpc, SpawnPoint0, Quaternion.identity);
        queue[0] =newNpc;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelSpawner : MonoBehaviour
{
    public GameObject plantillaCartel;

    List<GameObject> queue;

    // Posiciones en las que se estacionan o a las que se dirigen los carteles. 
    private Vector3 SpawnPoint0 = new Vector3(-14.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint1 = new Vector3(-11.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint2 = new Vector3(-7.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint3 = new Vector3(-3.0f, -1.51f, 0.0f);
    private Vector3 SpawnPoint4 = new Vector3(1.0f, -1.51f, 0.0f); 
    // Start is called before the first frame update
    void Start()
    {
        queue = new List<GameObject>();

        GameObject firstCartel = Instantiate(plantillaCartel, SpawnPoint1, Quaternion.identity);
        queue.Add(firstCartel);
        firstCartel.GetComponent<Cartel>().setInitialPosition(SpawnPoint0, SpawnPoint1);

        GameObject secondCartel = Instantiate(plantillaCartel, SpawnPoint2, Quaternion.identity);
        queue.Add(secondCartel);
        secondCartel.GetComponent<Cartel>().setInitialPosition(SpawnPoint1, SpawnPoint2);

        GameObject thirdCartel = Instantiate(plantillaCartel, SpawnPoint3, Quaternion.identity);
        queue.Add(thirdCartel);
        thirdCartel.GetComponent<Cartel>().setInitialPosition(SpawnPoint2, SpawnPoint3);

        GameObject fourthCartel = Instantiate(plantillaCartel, SpawnPoint4, Quaternion.identity);
        queue.Add(fourthCartel);
        fourthCartel.GetComponent<Cartel>().setInitialPosition(SpawnPoint3, SpawnPoint4);

    }
    void spawnCartel()
    {
        GameObject newcartel = Instantiate(plantillaCartel, SpawnPoint0, Quaternion.identity);
        queue[0] = newcartel;
        newcartel.GetComponent<Cartel>().setInitialPosition(SpawnPoint0, SpawnPoint1);
    }

    public void removeFromQueue()
    {
        GameObject aux = queue[3];
        for (int i = 3; i > 0; i--)
        {
            queue[i] = queue[i - 1];


            Destroy(aux);

        }

        updateNpcPosition();
        spawnCartel(); 
    }
    private void updateNpcPosition()
    {
        queue[1].GetComponent<Cartel>().updateTarget(SpawnPoint2);
        queue[2].GetComponent<Cartel>().updateTarget(SpawnPoint3);
        queue[3].GetComponent<Cartel>().updateTarget(SpawnPoint4);



    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

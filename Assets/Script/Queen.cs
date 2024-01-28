using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    private Vector3 defaultPosition = new Vector3(14.6f, -1.25f, 0.0f);
    private Vector3 peepPosition = new Vector3(8.94f, -1.25f, 0.0f);

    private float speed = 0.1f;

    private bool move = false;

    private void Update()
    {
        if (move)
            transform.position = Vector3.MoveTowards(transform.position, peepPosition, speed);
        else if (transform.position != defaultPosition)
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, speed);

    }

    public void peepIn()
    {
        move = true;
        Invoke("peepBack", 1.5f);
    }
    private void peepBack()
    {
        move = false;
    }

}

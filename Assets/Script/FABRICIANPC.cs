using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FABRICIANPC : MonoBehaviour
{

    // Atributos del Npc
    private int type;
    private int deck;
    private int hat;
    private int glasses;


    private Vector3 target;
    private Vector3 position;
    private Camera cam; 


    Rigidbody2D rb;
    public float velocity;
    SpriteRenderer rbSprite;
    private float minDistance = 0.2f;

    // Asignamos la posición inicial
    public void setInitialPosition(Vector3 currentPos, Vector3 nextTarget)
    {
        position = currentPos;
        target = nextTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target) > minDistance)
        {
            float step = velocity * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

    }

    public void updateTarget(Vector3 newTarget)
    {
        target = newTarget;
    }

}

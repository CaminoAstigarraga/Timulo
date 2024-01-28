using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    private Vector3 rejectedFinalTarget = new Vector3(-23.0f, -1.51f, 0);
    private Vector3 aceptedFinalTarget = new Vector3(16.0f, -1.51f, 0);


    private Rigidbody2D rb;
    private float velocity = 5.0f;
    private SpriteRenderer rbSprite;
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

        // Propiedades
        string gOName = gameObject.name;
        type = (int) char.GetNumericValue(gOName[0]);
        deck = (int)char.GetNumericValue(gOName[1]);
        hat = (int)char.GetNumericValue(gOName[2]);
        glasses = (int)char.GetNumericValue(gOName[3]);

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

    public void setDestination(int dir)
    {
        //Convertimos el collider en trigger
        gameObject.GetComponent<Collider2D>().isTrigger = true;

        // Aplicamos una máscara de color a los personajes y los movemos un layer por detrás para que no se superpongan
        byte rgbValue = 100;
        rbSprite.color = new Color32(rgbValue, rgbValue, rgbValue, 255);
        rbSprite.sortingOrder = 0;

        if (dir == 0)
        {
            target = aceptedFinalTarget;

        }
        else
        {
            target = rejectedFinalTarget;
            rbSprite.flipX = true;
            rbSprite.sortingOrder = 0;
        }
    }

}

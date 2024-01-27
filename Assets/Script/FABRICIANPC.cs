using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FABRICIANPC : MonoBehaviour
{
    private Vector2 target;
    private Vector2 position;
    private Camera cam; 


    Rigidbody2D rb;
    public float velocity;
    SpriteRenderer rbSprite;
    public float mindistance = 0.2f; 

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(5.21f, -1.51f); 

        position = gameObject.transform.position;
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float step = velocity * Time.deltaTime;

        if (Vector2.Distance(transform.position, target)> mindistance)
        {
 transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

      



       

    

       
    }

    
}

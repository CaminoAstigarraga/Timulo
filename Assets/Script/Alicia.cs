using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alicia : MonoBehaviour
{
    public Animator aliceAnimator;

    public bool YesPass;
    public bool NoPass; 

    // Start is called before the first frame update
    void Start()
    {
        aliceAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

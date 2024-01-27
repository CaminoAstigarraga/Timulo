using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alicia : MonoBehaviour
{
    public Animator aliceAnimator;
    public AudioSource aliciaAudios;

    public AudioClip audioYes;
    public AudioClip audioNo; 
    

    // Start is called before the first frame update
    void Start()
    {
        aliceAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(AliciaYes()); 
        }
    }
   public IEnumerator AliciaYes()
    {
        aliciaAudios.PlayOneShot(audioYes); 
        aliceAnimator.SetBool("YesPass", true);
        yield return new WaitForEndOfFrame();
        aliceAnimator.SetBool("YesPass", false); 
      
    }
    
   public IEnumerator AliciaNo()
    {
        aliciaAudios.PlayOneShot(audioNo); 
        aliceAnimator.SetBool("NoPass", true);
        yield return new WaitForSeconds(2);
        aliceAnimator.SetBool("NoPass", false);
        yield return null;
    }

  
}

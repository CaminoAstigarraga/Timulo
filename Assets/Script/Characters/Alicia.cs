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
    
   public IEnumerator AliciaYes()
    {
        aliciaAudios.PlayOneShot(audioYes); 
        aliceAnimator.SetBool("Pass", true);
        yield return new WaitForSeconds(0.2f);
        aliceAnimator.SetBool("Pass", false); 
      
    }
    
   public IEnumerator AliciaNo()
    {
        aliciaAudios.PlayOneShot(audioNo); 
        aliceAnimator.SetBool("Reject", true);
        yield return new WaitForSeconds(0.2f);
        aliceAnimator.SetBool("Reject", false);
    }
  
}

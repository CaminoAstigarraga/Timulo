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
        aliceAnimator.SetBool("YesPass", true);
        yield return new WaitForSeconds(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        aliceAnimator.SetBool("YesPass", false); 
      
    }
    
   public IEnumerator AliciaNo()
    {
        aliciaAudios.PlayOneShot(audioNo); 
        aliceAnimator.SetBool("NoPass", true);
        yield return new WaitForSeconds(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        aliceAnimator.SetBool("NoPass", false);
    }
  
}

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
    
   public void aliciaYesTrue()
    {
        Debug.Log("asd");
        aliceAnimator.SetBool("YesPass", true);
        /*aliciaAudios.PlayOneShot(audioYes); 
        aliceAnimator.SetBool("YesPass", true);
        yield return new WaitForSeconds(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        aliceAnimator.SetBool("YesPass", false); */

    }

    public void aliciaYesFalse()
    {
        aliceAnimator.SetBool("YesPass", false);
        /*aliciaAudios.PlayOneShot(audioYes); 
        aliceAnimator.SetBool("YesPass", true);
        yield return new WaitForSeconds(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        aliceAnimator.SetBool("YesPass", false); */

    }

    public void aliciaNoTrue()
    {

        aliceAnimator.SetBool("NoPass", true);
        /*aliciaAudios.PlayOneShot(audioNo); 
        aliceAnimator.SetBool("NoPass", true);
        yield return new WaitForSeconds(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log(this.aliceAnimator.GetCurrentAnimatorStateInfo(0).length);
        aliceAnimator.SetBool("NoPass", false);*/
    }

    public void aliciaNoFalse()
    {
        aliceAnimator.SetBool("NoPass", false);
    }

}

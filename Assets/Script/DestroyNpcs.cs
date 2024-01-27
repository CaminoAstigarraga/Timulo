using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNpcs : MonoBehaviour
{

    // Eliminamos a los personajes que ya se encuentran fuera de escena
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

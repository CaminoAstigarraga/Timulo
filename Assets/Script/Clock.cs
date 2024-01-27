using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    // Sprites del reloj
    public Image minuteHand;
    public Image hourHand;

    // variables para el reloj
    private bool isTimer = false;
    private float timer = 0.0f;
    private float timerSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        isTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        displayTime();
    }

    private void displayTime()
    {
        // Cuando el reloj llega al límite del tiempo
        if (timer > 210)
        {
            timer = 0;
        }

        // Giramos las manecillas del reloj según los 30 segundos del minutero y las 7 horas que representan los 3 minutos 30 segundos
        int hours = Mathf.FloorToInt(timer);
        hourHand.transform.localEulerAngles = new Vector3(0, 0, timer / 30 / 12 * (-360.0f));

        int minutes = Mathf.FloorToInt(timer);
        minuteHand.transform.localEulerAngles = new Vector3(0, 0, timer / 30 * (-360.0f));
    }
}

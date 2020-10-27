using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : ABaseEntity
{
    private float timeLeft = 60.0f;
    public float TimeLeft
    {
        get => timeLeft;
        set
        {
            timeLeft = value;
        }
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        this.GetComponent<Text>().text = "Time: " + (int)timeLeft;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : ABaseEntity
{
    private float timeLeft = 5.0f;
    public GameObject endScreen;
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
        if (timeLeft <= 0)
        {
            endScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}

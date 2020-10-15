using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : ABaseEntity
{
    public int value = 1;
    public ScoreManager scoreManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            scoreManager.Score += value;
        }
    }
}

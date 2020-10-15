using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : ABaseEntity
{
    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            this.GetComponent<Text>().text = "Score: " + score;
        }
    }

    public override void BaseStart()
    {
        this.GetComponent<Text>().text = "Score: 0";
    }
}

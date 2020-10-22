using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : ABaseEntity
{
    private int score = 0;
    private int difficulty = 0;
    private int maxDifficulty = 4;
    private int[] difficultyThresholds = { 10, 25, 50, 100 };
    public int Score
    {
        get => score;
        set
        {
            score = value;
            this.GetComponent<Text>().text = "Score: " + score;
            if (difficulty < maxDifficulty && score >= difficultyThresholds[difficulty])
            {
                Debug.Log("Difficulty up");
                difficulty++;
            }
        }
    }
    public int Difficulty
    {
        get => difficulty;
    }
    public override void BaseStart()
    {
        this.GetComponent<Text>().text = "Score: 0";
    }
}

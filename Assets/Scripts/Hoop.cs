using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : ABaseEntity
{
    public int value = 1;
    private int currentSpeed;
    public int[] speeds = { 0, 5, 15, 30, 50 };
    public Player player;
    public ScoreManager scoreManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            scoreManager.Score += value;
        }
    }
    public override void BaseUpdate()
    {
        if (scoreManager.Difficulty <= speeds.Length && currentSpeed != speeds[scoreManager.Difficulty])
        {
            currentSpeed = speeds[scoreManager.Difficulty];
        }

        this.transform.RotateAround(player.transform.position, Vector3.up, currentSpeed * Time.deltaTime);
    }
}

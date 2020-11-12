using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : ABaseEntity
{
    public int value = 1;
    private int currentSpeed;
    private Vector3 startPos;
    private float r;
    private float startHeight;
    public int[] speeds = { 0, 5, 15, 30, 50 };
    public int currentPattern = 0;
    public Player player;
    public ScoreManager scoreManager;
    public float vertMoveScale = 1.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            scoreManager.Score += value;
        }
    }

    public override void BaseStart()
    {
        Vector3 pos = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        startPos.Set(this.transform.parent.position.x, 0, this.transform.parent.position.z);
        currentSpeed = speeds[0];
        r = Vector3.Distance(startPos, pos);
        startHeight = this.transform.parent.position.y;
    }
    public override void BaseUpdate()
    {
        if (scoreManager.Difficulty <= speeds.Length && currentSpeed != speeds[scoreManager.Difficulty])
        {
            currentSpeed = speeds[scoreManager.Difficulty];
            currentPattern++;
            if (currentPattern == 3)
            {
                startPos.Set(this.transform.parent.position.x, 0, this.transform.parent.position.z);
            }
        }

        switch (currentPattern)
        {
            case 4:
            case 3:
                Vector3 pos = new Vector3(this.transform.parent.position.x, 0, this.transform.parent.position.z);
                float theta = (Vector3.SignedAngle(startPos, pos, Vector3.up));
                this.transform.parent.position = new Vector3(this.transform.parent.position.x, startHeight + (Mathf.Sin(theta * Mathf.Deg2Rad) * vertMoveScale), this.transform.parent.position.z);
                goto case 2;
            case 2:
            case 1:
                this.transform.parent.RotateAround(player.transform.position, Vector3.up, currentSpeed * Time.deltaTime);
                break;
            case 0:
                break;
            default:
                goto case 4;
        }
    }
}

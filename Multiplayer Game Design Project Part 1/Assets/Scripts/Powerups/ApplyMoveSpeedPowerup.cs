using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMoveSpeedPowerup : ApplyPowerup
{
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (powerupApplied)
        {
            SetTimer();

            powerupApplied = false;
        }

        if (timeToPowerupEnd < Time.realtimeSinceStartup && powerupActive)
        {
            DisablePowerup();
        }
    }

    public override void ActivatePowerup()
    {
        player.SetSpeed(player.GetSpeed() * 1.5f);

        powerupApplied = true;
        powerupActive = true;

        print("Speed Increased");
    }

    public override void DisablePowerup()
    {
        player.SetSpeed(player.GetSpeed() / 1.5f);

        powerupActive = false;

        print("Speed returned to normal");
    }

    public override void SetTimer()
    {
        timeToPowerupEnd = Time.realtimeSinceStartup + activeTime;
    }
}

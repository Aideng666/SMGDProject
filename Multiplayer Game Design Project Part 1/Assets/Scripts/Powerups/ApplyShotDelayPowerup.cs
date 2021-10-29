using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyShotDelayPowerup : ApplyPowerup
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
        player.SetShotDelay(player.GetShotDelay() / 1.5f);

        powerupApplied = true;
        powerupActive = true;

        print("Shot Delay Lowered");
    }

    public override void DisablePowerup()
    {
        player.SetShotDelay(player.GetShotDelay() * 1.5f);

        powerupActive = false;

        print("Shot Delay Returned to normal");
    }

    public override void SetTimer()
    {
        timeToPowerupEnd = Time.realtimeSinceStartup + activeTime;
    }
}

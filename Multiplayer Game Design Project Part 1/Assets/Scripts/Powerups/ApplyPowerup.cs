using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplyPowerup : MonoBehaviour
{
    protected PlayerController player;
    protected bool powerupApplied;
    protected bool powerupActive;
    protected float timeToPowerupEnd;
    protected float activeTime = 10;

    public abstract void ActivatePowerup();
    public abstract void DisablePowerup();
    public abstract void SetTimer();
}

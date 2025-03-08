using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public event Action<float> OnHit;

    public void Attack(float damage)
    {
        OnHit?.Invoke(damage);
    }
}

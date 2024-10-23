using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public int maxhitPoints;
    
    [HideInInspector] public UnityEvent Distruct;
    [HideInInspector] public UnityEvent ChangeHitPoints;
    
    private int hitPoints;

    private bool isDistruct = false;

    private void Start()
    {
        hitPoints = maxhitPoints;
        ChangeHitPoints.Invoke();
    }
  
    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        if (isDistruct == true) return;
        hitPoints = 0;
        isDistruct = true;

        ChangeHitPoints.Invoke();
        Distruct.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pikup : MonoBehaviour
{
    [HideInInspector] public UnityEvent CollisionCoin;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
       Cart cart  = collision.GetComponent<Cart>();
        
        if (cart != null)
        {
            Destroy(gameObject);
        }
    }
}

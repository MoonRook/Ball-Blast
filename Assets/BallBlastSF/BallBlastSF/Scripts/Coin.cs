using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pikup
{   
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Bag bag = collision.transform.root.GetComponent<Bag>();

        if (bag != null)
        {
            bag.AddCoin(1);
          
            Destroy(gameObject);
        }
    }
}

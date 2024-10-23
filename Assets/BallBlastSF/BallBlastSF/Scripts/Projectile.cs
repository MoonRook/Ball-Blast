using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    
    private int damage;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        // transform.position += transform.up * speed * Time.deltaTime;
        transform.Translate(0, speed * Time.deltaTime, 0); // тот же самый код
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructible destructible = collision.transform.root.GetComponent<Destructible>();

        if (destructible != null)
        {
            destructible.ApplyDamage(damage);
        }
        
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}

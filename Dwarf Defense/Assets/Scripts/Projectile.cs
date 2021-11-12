using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public float damage = 20;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        var hp = otherCollision.GetComponent<Health>();
        var attacker = otherCollision.GetComponent<Attacker>();

        if (attacker && hp) // if the gameObject has Attacker.cs and Health.cs
        {
            hp.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}

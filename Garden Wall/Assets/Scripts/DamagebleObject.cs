using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleObject : MonoBehaviour
{
    public int healthPoints;
    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        //Debug.Log(damage);
        if (healthPoints <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

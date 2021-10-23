using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float speedAttack;
    public int damage;
    private bool endOfAttack;
    public Transform attackPoint;
    public float rangeAttack;

    void Start()
    {
        endOfAttack = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && endOfAttack)
        {
            //опять же, здесь должна быть анимация, но Вика еще ничего не рисовала
            //так что здесь будет это
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, rangeAttack);
            if (enemies.Length != 0)
            {
                foreach (Collider2D enemy in enemies)
                {
                    if (enemy.GetComponent<DamagebleObject>())
                        enemy.GetComponent<DamagebleObject>().TakeDamage(damage);
                }
            }
            StartCoroutine(Waiter());
        }
    }
    IEnumerator Waiter()
    {
        endOfAttack = false;
        yield return new WaitForSeconds(speedAttack);
        endOfAttack = true;
    }
}

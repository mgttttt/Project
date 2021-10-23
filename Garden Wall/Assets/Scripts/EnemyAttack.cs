using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int _damage;
    public int _speedAttack;
    [SerializeField] private GameObject _player;
    private bool endOfAttack;
    void Start()
    {
        endOfAttack = true;
    }

    void Update()
    {
        EnemyController enemyController = GetComponent<EnemyController>();
        if (enemyController.GetIsCoughtUp() && endOfAttack)
        {
            StartCoroutine(Waiter());
        }
    }
    IEnumerator Waiter()
    {
        endOfAttack = false;
        _player.GetComponent<CharacterController>().TakeDamage(_damage);
        yield return new WaitForSeconds(_speedAttack);
        endOfAttack = true;
    }
}

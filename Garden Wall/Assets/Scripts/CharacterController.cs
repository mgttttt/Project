using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _body;
    public float jumpForce = 12f;
    private BoxCollider2D _box;
    private Animator _anim;
    public int _healthPoints;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            if (deltaX >= 0)
                transform.localScale = new Vector3(2f, 2f, 2f);
            else
            {
                transform.localScale = new Vector3(-2f, 2f, 2f);
            }
        }

    }
    public void TakeDamage(int _damage)
    {
        _healthPoints -= _damage;
        Debug.Log(_healthPoints);
    }
}

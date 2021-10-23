using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public float maxX;
    public float minX;
    public float speed;
    private bool isLeft;
    private bool isCubeSawThePlayer;
    [System.NonSerialized] public bool isCoughtUp;

    void Start()
    {
        isLeft = false;
        isCoughtUp = false;
        isCubeSawThePlayer = false;
    }

    void Update()
    {
        float deltaX;
        Rigidbody2D _body = GetComponent<Rigidbody2D>();
        if ((isCubeSawThePlayer) && (Mathf.Abs(_player.transform.position.x - _body.transform.position.x) < 10))
        {
            if ((!isCoughtUp)&&(Mathf.Abs(_player.transform.position.x - _body.transform.position.x) > 0.5))
            {
                if (_player.transform.position.x > _body.transform.position.x)
                {
                    deltaX = (speed + 3) * Time.fixedDeltaTime;
                    _body.velocity = new Vector2(deltaX, _body.velocity.y);
                }
                else
                {
                    deltaX = -(speed + 3) * Time.fixedDeltaTime;
                    _body.velocity = new Vector2(deltaX, _body.velocity.y);
                }
                if (Mathf.Abs(_player.transform.position.x - _body.transform.position.x) <= 1)
                    isCoughtUp = true;
                else
                    isCoughtUp = false;
            }
            else
            {
                Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                GetComponent<Renderer>().material.color = random;
                if (Mathf.Abs(_player.transform.position.x - _body.transform.position.x) >= 1)
                    isCoughtUp = false;
                //Здесь должна быть анимация, но Вика еще ничего не нарисовала
                //так что кубик просто будет менять цвет
            }
        }
        else
        {
            isCubeSawThePlayer = false;
            if (isLeft)
                deltaX = -speed * Time.fixedDeltaTime;
            else
                deltaX = speed * Time.fixedDeltaTime;
            _body.velocity = new Vector2(deltaX, _body.velocity.y);
            if (_body.transform.position.x > (maxX - 1))
            {
                _body.transform.Rotate(0, 180, 0);
                isLeft = true;
            }
            if (_body.transform.position.x < (minX + 1))
            {
                _body.transform.Rotate(0, 180, 0);
                isLeft = false;

            }
            RaycastHit2D hit;
            Vector3 offset = new Vector3(transform.localScale.x / 2 + 0.01f, 0, 0);
            if (isLeft)
                hit = Physics2D.Raycast(transform.position - offset, Vector2.left);
            else
                hit = Physics2D.Raycast(transform.position + offset, Vector2.right);
            if ((hit.collider != null)&& (hit.collider.CompareTag("Player") && (hit.distance < 8)))
                isCubeSawThePlayer = true;
        }
    }
    public bool GetIsCoughtUp()
    {
        return isCoughtUp;
    }
}

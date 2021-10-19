using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public Vector3 offset;
    public float interpolate;
    void Start()
    {
        
    }

    void Update()
    {
        if (_player.transform.localScale.x < 0)
        {
            offset.x = -1;
        }
        else
        {
            offset.x = 1;
        }
        Vector3 pos = new Vector3(_player.transform.position.x, 0, gameObject.transform.position.z) + offset;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, pos, interpolate * Time.deltaTime);
    }
}

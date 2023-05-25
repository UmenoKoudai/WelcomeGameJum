using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    public Vector3 _direction;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = _direction * _moveSpeed;
    }
}

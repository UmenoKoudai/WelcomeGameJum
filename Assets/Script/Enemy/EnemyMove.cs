using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] _movePoint;
    [SerializeField] float _distance;
    [SerializeField] float _moveSpeed;
    [SerializeField] MoveType _moveType = MoveType.Stay;
    int _n;
    public MoveType Type { get => _moveType; set => _moveType = value; }
    void Update()
    {
        if (_moveType == MoveType.Move)
        {
            float distance = Vector3.Distance(_movePoint[_n % _movePoint.Length].position, transform.position);
            if (distance > _distance)
            {
                Vector3 dir = _movePoint[_n % _movePoint.Length].position - transform.position;
                GetComponent<Rigidbody2D>().velocity = dir * _moveSpeed;
            }
            else
            {
                _n++;
            }
        }
    }

    public enum MoveType
    {
        Stay,
        Move,
    }
}

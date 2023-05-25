using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] GameObject _subWeaponLeft;
    [SerializeField] GameObject _subWeaponRigiht;
    BulletCreate _createScript;
    EnemyMove _moveScript;
    BulletCreate _createLeft;
    BulletCreate _createRight;
    int _maxHp;
    public int HP { get => _hp; set => _hp = value; }

    private void Awake()
    {
        _createScript = GetComponent<BulletCreate>();
        _moveScript = GetComponent<EnemyMove>();
        _createLeft = _subWeaponLeft.GetComponent<BulletCreate>();
        _createRight = _subWeaponRigiht.GetComponent<BulletCreate>();
        _maxHp = _hp;
    }

    private void Update()
    {
        if(_hp < _maxHp / 3)
        {
            Debug.Log("3•ª‚Ì1");
            _moveScript.Type = EnemyMove.MoveType.Move;
            _createScript.Type = BulletCreate.BulletType.Wave;
            _createLeft.Type = BulletCreate.BulletType.Circle;
            _createRight.Type = BulletCreate.BulletType.Circle;
        }
        else if (_hp < _maxHp / 2)
        {
            Debug.Log("”¼•ª");
            _createScript.Type = BulletCreate.BulletType.Circle;
        }
        if (_hp < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }
}

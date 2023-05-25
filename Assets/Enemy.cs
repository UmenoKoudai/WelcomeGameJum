using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _hp;
    public int HP { get; set; }


    private void Update()
    {
        if(_hp < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }
}

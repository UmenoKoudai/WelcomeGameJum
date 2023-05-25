using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBullet : MonoBehaviour
{
    [SerializeField] int _power;
    [SerializeField] int _speed;
    [SerializeField] GameObject _effect;

    private void Start()
    {
        _power = FindObjectOfType<player>().Power;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(_power);
            Instantiate(_effect, transform.position, transform.rotation);
        }
    }
}

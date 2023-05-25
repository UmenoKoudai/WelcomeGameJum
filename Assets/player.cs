using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _interval;
    [SerializeField] Transform _muzzle;
    [SerializeField] int _power;
    Rigidbody2D _rb;
    float _timer;
    public int Power { get => _power; set => _power = value; }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(x, y) * _moveSpeed;
        if(_timer > _interval)
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation);
            _timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameManager>().PlayerDamage();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "PowerUp")
        {
            collision.gameObject.GetComponent<ItemBase>().ItemAction();
        }
    }
}

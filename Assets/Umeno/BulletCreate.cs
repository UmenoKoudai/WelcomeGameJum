using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _muzzle;
    [SerializeField] Transform _bulletDir;
    [SerializeField]BulletType _bulletType = BulletType.Wave;
    [SerializeField] float _interval;
    [SerializeField] float _radius;
    [SerializeField] float rotateSpeedX;
    [SerializeField] float rotateSpeedY;
    EnemyBullet _bulletScript;
    float _timer;

    public BulletType Type { get => _bulletType; set => _bulletType = value; }
    // Start is called before the first frame update
    void Start()
    {
        _bulletScript = _bullet.GetComponent<EnemyBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_bulletType != BulletType.None)
        {
            _timer += Time.deltaTime;
            _bulletScript._direction = _bulletDir.position - _muzzle.position;
            if (_timer > _interval)
            {
                Instantiate(_bullet, _muzzle.position, transform.rotation);
                _timer = 0;
            }
        }
        float x = Mathf.Cos(Time.time * rotateSpeedX);
        float y = Mathf.Sin(Time.time * rotateSpeedY);
        if (_bulletType == BulletType.Circle)
        {
            _radius = 1;
            Vector3 nowPopsition = transform.position;
            _muzzle.position = new Vector2(nowPopsition.x + x * _radius, nowPopsition.y + y * _radius);
            _bulletDir.position = new Vector2(nowPopsition.x + x * (_radius * 2), nowPopsition.y + y * (_radius * 2));
        }
        if(_bulletType == BulletType.Wave)
        {
            _radius = 0.3f;
            Vector3 nowPopsition = new Vector2(transform.position.x, transform.position.y - 1);
            _muzzle.position = new Vector2(nowPopsition.x + x * _radius, nowPopsition.y + -_radius);
            _bulletDir.position = new Vector2(nowPopsition.x + x * (_radius * 2), nowPopsition.y - _radius * 2);
        }
    }

    public enum BulletType
    {
        None,
        Circle,
        Wave,
    }
}

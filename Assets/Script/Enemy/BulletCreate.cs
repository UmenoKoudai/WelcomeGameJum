using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    [SerializeField, Tooltip("”­Ë‚·‚é’e‚ÌPrefab")] GameObject _bullet;
    [SerializeField, Tooltip("’e‚ğ”­Ë‚·‚éêŠ")] Transform _muzzle;
    [SerializeField, Tooltip("’e‚ªŒü‚©‚¤•ûŒü")] Transform _bulletDir;
    [SerializeField, Tooltip("’e‚Ì‹O“¹‚ğØ‚è‘Ö‚¦‚é")] BulletType _bulletType = BulletType.Wave;
    [SerializeField, Tooltip("’e‚Ì”­ËŠÔŠu")] float _interval;
    [SerializeField, Tooltip("‰ñ“]‚Ì”¼Œa")] float _radius;
    [SerializeField, Tooltip("‰ñ“]‘¬“xX")] float rotateSpeedX;
    [SerializeField, Tooltip("‰ñ“]‘¬“xY")] float rotateSpeedY;
    float _timer;

    public BulletType Type { get => _bulletType; set => _bulletType = value; }

    void Update()
    {
        //’e‚ğ”­Ë‚µ‚È‚¢
        if (_bulletType != BulletType.None)
        {
            _timer += Time.deltaTime;
            //’e‚ÌˆÚ“®•ûŒü‚ğEnemyBulletƒXƒNƒŠƒvƒg‚Ì•Ï”‚É‘ã“ü
            _bullet.GetComponent<EnemyBullet>()._direction = _bulletDir.position - _muzzle.position;
            if (_timer > _interval)
            {
                Instantiate(_bullet, _muzzle.position, transform.rotation);
                _timer = 0;
            }
        }
        //OŠpŠÖ”‚ÅƒIƒuƒWƒFƒNƒg‚ğ‰ñ“]‚³‚¹‚é
        float x = Mathf.Cos(Time.time * rotateSpeedX);
        float y = Mathf.Sin(Time.time * rotateSpeedY);
        if (_bulletType == BulletType.Circle)
        {
            _radius = 1;
            Vector3 nowPopsition = transform.position;
            //”­ËêŠ‚ğ‰ñ“]‚³‚¹‚é©•ª‚ÌˆÊ’u‚ğ‘«‚·–‚Å¡‚Ì“G‚ÌˆÊ’u‚ğ‹N“_‚É‰ñ“]‚·‚é(X = ”¼Œa~Cos(ƒÆ), Y = ”¼Œa~Sin(ƒÆ))
            _muzzle.position = new Vector2(nowPopsition.x + x * _radius, nowPopsition.y + y * _radius);
            //’e‚Ì•ûŒü‚¾‚©‚ç”­ËêŠ‚æ‚è‘å‚«‚¢”¼Œa‚Å‰ñ“]‚³‚¹‚é
            _bulletDir.position = new Vector2(nowPopsition.x + x * (_radius * 2), nowPopsition.y + y * (_radius * 2));
        }
        if(_bulletType == BulletType.Wave)
        {
            _radius = 0.3f;
            //“G‚Ì’†‰›‚©‚ç­‚µ‰º‚É‹N“_‚ğİ’è‚·‚é
            Vector3 nowPopsition = new Vector2(transform.position.x, transform.position.y - _radius);
            _muzzle.position = new Vector2(nowPopsition.x + x * _radius, nowPopsition.y);
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

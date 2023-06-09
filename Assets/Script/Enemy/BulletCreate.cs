using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    [SerializeField, Tooltip("発射する弾のPrefab")] GameObject _bullet;
    [SerializeField, Tooltip("弾を発射する場所")] Transform _muzzle;
    [SerializeField, Tooltip("弾が向かう方向")] Transform _bulletDir;
    [SerializeField, Tooltip("弾の軌道を切り替える")] BulletType _bulletType = BulletType.Wave;
    [SerializeField, Tooltip("弾の発射間隔")] float _interval;
    [SerializeField, Tooltip("回転の半径")] float _radius;
    [SerializeField, Tooltip("回転速度X")] float rotateSpeedX;
    [SerializeField, Tooltip("回転速度Y")] float rotateSpeedY;
    float _timer;

    public BulletType Type { get => _bulletType; set => _bulletType = value; }

    void Update()
    {
        //弾を発射しない
        if (_bulletType != BulletType.None)
        {
            _timer += Time.deltaTime;
            //弾の移動方向をEnemyBulletスクリプトの変数に代入
            _bullet.GetComponent<EnemyBullet>()._direction = _bulletDir.position - _muzzle.position;
            if (_timer > _interval)
            {
                Instantiate(_bullet, _muzzle.position, transform.rotation);
                _timer = 0;
            }
        }
        //三角関数でオブジェクトを回転させる
        float x = Mathf.Cos(Time.time * rotateSpeedX);
        float y = Mathf.Sin(Time.time * rotateSpeedY);
        if (_bulletType == BulletType.Circle)
        {
            _radius = 1;
            Vector3 nowPopsition = transform.position;
            //発射場所を回転させる自分の位置を足す事で今の敵の位置を起点に回転する(X = 半径×Cos(θ), Y = 半径×Sin(θ))
            _muzzle.position = new Vector2(nowPopsition.x + x * _radius, nowPopsition.y + y * _radius);
            //弾の方向だから発射場所より大きい半径で回転させる
            _bulletDir.position = new Vector2(nowPopsition.x + x * (_radius * 2), nowPopsition.y + y * (_radius * 2));
        }
        if(_bulletType == BulletType.Wave)
        {
            _radius = 0.3f;
            //敵の中央から少し下に起点を設定する
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

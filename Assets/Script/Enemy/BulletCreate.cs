using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    [SerializeField, Tooltip("���˂���e��Prefab")] GameObject _bullet;
    [SerializeField, Tooltip("�e�𔭎˂���ꏊ")] Transform _muzzle;
    [SerializeField, Tooltip("�e������������")] Transform _bulletDir;
    [SerializeField, Tooltip("�e�̋O����؂�ւ���")] BulletType _bulletType = BulletType.Wave;
    [SerializeField, Tooltip("�e�̔��ˊԊu")] float _interval;
    [SerializeField, Tooltip("��]�̔��a")] float _radius;
    [SerializeField, Tooltip("��]���xX")] float rotateSpeedX;
    [SerializeField, Tooltip("��]���xY")] float rotateSpeedY;
    float _timer;

    public BulletType Type { get => _bulletType; set => _bulletType = value; }

    void Update()
    {
        //�e�𔭎˂��Ȃ�
        if (_bulletType != BulletType.None)
        {
            _timer += Time.deltaTime;
            //�e�̈ړ�������EnemyBullet�X�N���v�g�̕ϐ��ɑ��
            _bullet.GetComponent<EnemyBullet>()._direction = _bulletDir.position - _muzzle.position;
            if (_timer > _interval)
            {
                Instantiate(_bullet, _muzzle.position, transform.rotation);
                _timer = 0;
            }
        }
        //�O�p�֐��ŃI�u�W�F�N�g����]������
        float x = Mathf.Cos(Time.time * rotateSpeedX);
        float y = Mathf.Sin(Time.time * rotateSpeedY);
        if (_bulletType == BulletType.Circle)
        {
            _radius = 1;
            Vector3 nowPopsition = transform.position;
            //���ˏꏊ����]�����鎩���̈ʒu�𑫂����ō��̓G�̈ʒu���N�_�ɉ�]����(X = ���a�~Cos(��), Y = ���a�~Sin(��))
            _muzzle.position = new Vector2(nowPopsition.x + x * _radius, nowPopsition.y + y * _radius);
            //�e�̕��������甭�ˏꏊ���傫�����a�ŉ�]������
            _bulletDir.position = new Vector2(nowPopsition.x + x * (_radius * 2), nowPopsition.y + y * (_radius * 2));
        }
        if(_bulletType == BulletType.Wave)
        {
            _radius = 0.3f;
            //�G�̒������班�����ɋN�_��ݒ肷��
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

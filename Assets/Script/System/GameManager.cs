using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _playerCouunt;
    [SerializeField] GameObject _enemy;
    [SerializeField] Transform _muzzle;
    [SerializeField] GameObject _player;
    [SerializeField] Text _countText;
    [SerializeField] GameObject _sceneMove;
    [SerializeField] GameObject _playStart;
    Enemy _enemyScript;

    public int PlayerCount { get => _playerCouunt; set => _playerCouunt = value; }

    void Start()
    {
        _enemyScript = _enemy.GetComponent<Enemy>();
    }

    void Update()
    {
        _countText.text = $"{_playerCouunt}";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
        if(_playerCouunt < 0)
        {
            _sceneMove.GetComponent<scenechange>().SeneLoad("GameOver");
        }
        if(FindObjectsOfType<Enemy>().Length < 1)
        {
            _sceneMove.GetComponent<scenechange>().SeneLoad("Game Clear");
        }
    }

    public void PlayerDamage()
    {
        _playerCouunt--;
        Instantiate(_playStart, new Vector3(0, -5, 0), transform.rotation);
    }

    public void BulletDestroy()
    {
        var _bullets = FindObjectsOfType<EnemyBullet>();
        for(int i = 0; i < _bullets.Length; i++)
        {
            Destroy(_bullets[i].gameObject);
        }
    }

    public void ResPown()
    {
        Instantiate(_player, _muzzle.position, transform.rotation);
    }
}

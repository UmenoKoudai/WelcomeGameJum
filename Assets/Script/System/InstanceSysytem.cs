using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSysytem<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    Debug.LogError($"{typeof(T).Name}���A�^�b�`���ꂽ�I�u�W�F�N�g�����݂��܂���");
                }
            }

            return _instance;
        }
    }
}

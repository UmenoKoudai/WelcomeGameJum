using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log(GetComponent<Enemy>().HP);
            GetComponent<Enemy>().Damage(10);
        }
    }
}

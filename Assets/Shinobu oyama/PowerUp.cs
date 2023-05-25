using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    public Rigidbody PowerRb;
    // Start is called before the first frame update
    void Start()
    {
        PowerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

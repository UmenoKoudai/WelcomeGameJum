using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respown : MonoBehaviour
{
    public void Spown()

    {
        FindObjectOfType<GameManager>().ResPown();
        Destroy(gameObject);
    }
}

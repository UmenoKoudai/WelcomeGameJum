using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDestroy : ItemBase
{
    public override void ItemAction()
    {
        Debug.Log("�j��");
        FindObjectOfType<GameManager>().BulletDestroy();
    }
}

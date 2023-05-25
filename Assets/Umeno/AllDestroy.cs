using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDestroy : ItemBase
{
    public override void ItemAction()
    {
        Debug.Log("”j‰ó");
        FindObjectOfType<GameManager>().BulletDestroy();
    }
}

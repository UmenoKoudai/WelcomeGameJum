using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : ItemBase
{
    public override void ItemAction()
    {
        Debug.Log("パワーアップ");
        FindObjectOfType<player>().Power += 5; ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeitem : ItemBase
{
    public override void ItemAction()
    {
        Debug.Log("�p���[�A�b�v");
        FindObjectOfType<GameManager>().PlayerCount++;
    }
}

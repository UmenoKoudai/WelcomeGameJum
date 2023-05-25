using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : InstanceSysytem<AudioController>
{
    [SerializeField] AudioClip[] _se;
    public void SePlay(SeClip _selectSe)
    {
        int index = (int)_selectSe;
        GetComponent<AudioSource>().PlayOneShot(_se[index]);
    }

    public enum SeClip
    {
        Shoot,
        Get,
        Destroy,
    }
}

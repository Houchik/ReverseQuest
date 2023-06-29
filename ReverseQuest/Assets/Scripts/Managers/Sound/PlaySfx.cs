using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySfx : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public void PlayTheSfx()
    {
        SoundManager.Instance.PlayAudio(_clip);
    }

}

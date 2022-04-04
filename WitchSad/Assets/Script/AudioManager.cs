using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("오디오 플레이어")]
    [SerializeField]
    public AudioSource audioPlayer;

    [Header("오디오 클립")]
    [SerializeField]
    public AudioClip[] audioClip;

}

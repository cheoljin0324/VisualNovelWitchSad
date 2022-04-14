using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DialgoueManager : MonoBehaviour
{
    [SerializeField]
    private VisualNovel[] vinovel;
    [SerializeField]
    private AudioManager audioGate;
    [SerializeField]
    private SelectScreen selecT;
    [SerializeField]
    private FadeObject FadeInOut;

    [SerializeField]
    private AudioClip[] bgmClip;

    private IEnumerator Start()
    {
        audioGate.audioPlayer.clip = audioGate.audioClip[0];
        audioGate.audioPlayer.Play();

        yield return new WaitUntil(()=>vinovel[0].UpdateDialog());

        yield return new WaitUntil(() => selecT.InstButton());

        FadeInOut.Fade();
        yield return new WaitForSeconds(1.2f);

        yield return new WaitUntil(() => vinovel[1].UpdateDialog());
    }
}

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

        selecT.InstButton();
        yield return new WaitUntil(() => selecT.inSelect==true);

        FadeInOut.Fade();
        yield return new WaitForSeconds(1.2f);

        if (selecT.SelectNum == 1)
        {
            yield return new WaitUntil(() => vinovel[1].UpdateDialog());
        }
        else if(selecT.SelectNum == 2)
        {
            yield return new WaitUntil(() => vinovel[2].UpdateDialog());
        }
    }
}

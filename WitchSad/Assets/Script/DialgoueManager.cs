using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DialgoueManager : MonoBehaviour
{
    [SerializeField]
    private VisualNovel[] vinovel;

    private IEnumerator Start()
    {
        yield return new WaitUntil(()=>vinovel[0].UpdateDialog());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeObject : MonoBehaviour
{
    private SpriteRenderer spriteBack;
    private bool isFade = false;

    private void Start()
    {
        spriteBack = GetComponent<SpriteRenderer>();
    }

    public bool Fade()
    {
        StartCoroutine(FadeObjectBack());
        return isFade = true;
    }

    IEnumerator FadeObjectBack()
    {
        spriteBack.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        spriteBack.DOFade(0f, 0.5f);

       
    }
}

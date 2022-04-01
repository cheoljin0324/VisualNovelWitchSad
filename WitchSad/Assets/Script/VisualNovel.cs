using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using DG.Tweening;


public class VisualNovel : MonoBehaviour
{
    [SerializeField]
    private Proflie[] proflie;
    [SerializeField]
    private Dialogue[] dialogues;

    private bool isFirst = true;
    private bool isAuto = true;
    private int currentDialogueIndex = -1;
    private int currentCharIndex = 0;
    private float typingspd = 0.03f;
    private bool isTyping = false;
    private bool isAnimation = false;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        for(int i = 0; i<proflie.Length; ++i)
        {
            SetActiveObjects(proflie[i], false);
        }

    }

    public bool UpdateDialog()
    {
       
        if(isFirst == true)
        {
            Setup();
            if (isAuto) SetNextDialog();
            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentDialogueIndex+1 > dialogues.Length)
            {
               if (currentDialogueIndex <= dialogues.Length&&proflie[dialogues[currentDialogueIndex].CharacterNum].CharacterSprite.sprite != proflie[dialogues[currentDialogueIndex + 1].CharacterNum].CharacterSprite.sprite)
            {
                isAnimation = true;
            }

            }

            if (isTyping == true)
            {
                isTyping = false;

                StopCoroutine("Ontyping");
                proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData;
                proflie[currentCharIndex].Arrow.gameObject.SetActive(true);
            }

            if (dialogues.Length > currentDialogueIndex + 1)
            {
                SetNextDialog();
            }
            else
            {
                for(int i = 0; i<proflie.Length; ++i)
                {
                    SetActiveObjects(proflie[i], false);
                   
                }
                return true;
            }
        }
        return false;
    }

    public void SetNextDialog()
    {
        SetActiveObjects(proflie[currentCharIndex], false);

        currentDialogueIndex++;
        currentCharIndex = dialogues[currentDialogueIndex].CharacterNum;

     
        proflie[currentCharIndex].CharacterSprite.sprite = proflie[currentCharIndex].CharacterEmotion[dialogues[currentDialogueIndex].Emotion];
       

        SetActiveObjects(proflie[currentCharIndex], true);

        proflie[currentCharIndex].nameText.text = proflie[currentCharIndex].name;
        proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData;
        StartCoroutine("Ontyping");
    }

    private void SetActiveObjects(Proflie profiles , bool visable)
    {
        if (visable == true)
        {
            if (dialogues[currentDialogueIndex].angryEvent == true)
            {
                StartCoroutine(Shake());
            }
            if (currentDialogueIndex == 0)
            {
                profiles.CharacterSprite.color = profiles.CharacterSprite.color * new Color(1, 1, 1, 0);
                profiles.CharacterSprite.DOFade(1f, 1f);
            }
            else if (profiles.CharacterSprite.sprite != proflie[dialogues[currentDialogueIndex-1].CharacterNum].CharacterSprite.sprite)
            {
                profiles.CharacterSprite.color = profiles.CharacterSprite.color * new Color(1, 1, 1, 0);
                profiles.CharacterSprite.DOFade(1f, 1f);
            }
                StartCoroutine(FalseOb(profiles, visable));
        }


        else if(visable == false)
        {
            if (isAnimation == true)
            {
                profiles.CharacterSprite.DOFade(0f, 0.2f);
            }
            StartCoroutine(FalseOb(profiles, visable));

        }

        profiles.dialoguePanel.gameObject.SetActive(visable);
        profiles.nameText.gameObject.SetActive(visable);
        profiles.dialgoueText.gameObject.SetActive(visable);

        profiles.Arrow.gameObject.SetActive(false);
    }

    IEnumerator Ontyping()
    {
        int index = 0;

        isTyping = true;

        WaitForSeconds waitForSeconds = new WaitForSeconds(typingspd);
        while (index < dialogues[currentDialogueIndex].DialogueComData.Length)
        {
            proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData.Substring(0, index+1);

            index++;

            yield return waitForSeconds;
        }
        isTyping = false;
        proflie[currentCharIndex].Arrow.gameObject.SetActive(true);
    }

    IEnumerator FalseOb(Proflie profiles,bool visable)
    {
        if(visable == true)
        {
            profiles.CharacterSprite.gameObject.SetActive(visable);
        }
        else if(visable == false)
        {
            if (isAnimation == true)
            {
                yield return new WaitForSeconds(0.4f);
                isAnimation = false;
                profiles.CharacterSprite.gameObject.SetActive(visable);
            }
            else
            {
                profiles.CharacterSprite.gameObject.SetActive(visable);
            }
            }
        }

    IEnumerator Shake()
    {
        for(int i = 0; i<10; i++)
        {
            proflie[currentCharIndex].CharacterSprite.transform.DOMove(new Vector3(proflie[currentCharIndex].CharacterSprite.transform.position.x+0.1f, proflie[currentCharIndex].CharacterSprite.transform.position.y, 0f), 0.05f, false);
            yield return new WaitForSeconds(0.05f);
            proflie[currentCharIndex].CharacterSprite.transform.DOMove(new Vector3(proflie[currentCharIndex].CharacterSprite.transform.position.x-0.1f, proflie[currentCharIndex].CharacterSprite.transform.position.y, 0f), 0.05f, false);
            yield return new WaitForSeconds(0.05f);
        }
    }
       
    }
 

   


[System.Serializable]
public struct Proflie
{
    [Header("이름")]
    public string name;

    [Header("캐릭터 메인 이미지")]
    public SpriteRenderer CharacterSprite;
    [Header("캐릭터 감정 모션")]
    public Sprite[] CharacterEmotion;

    [Header("대화창 이미지")]
    public Image dialoguePanel;
    [Header("플레이어 이름 출력 텍스트")]
    public Text nameText;
    [Header("플레이어 대화 출력 텍스트")]
    public Text dialgoueText;

    [Header("오브젝트가 끝났음을 알려주는 이미지")]
    public Image Arrow;

}

[System.Serializable]
public struct Dialogue
{
    [Header("사용 할 캐릭터 넘버즈")]
    public int CharacterNum;

    [Header("해당 캐릭터 감정 고유번호")]
    public int Emotion;

    [Header("화난 효과")]
    public bool angryEvent;

    [Header("대화")]
    [TextArea(3, 5)]
    public string DialogueComData;
}




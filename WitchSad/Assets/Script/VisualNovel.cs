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
            if(isTyping == true)
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
                   
                        proflie[i].CharacterSprite.gameObject.SetActive(false);
                   
                   
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
       
            profiles.CharacterSprite.gameObject.SetActive(visable);
       
        profiles.dialoguePanel.gameObject.SetActive(visable);
        profiles.nameText.gameObject.SetActive(visable);
        profiles.dialgoueText.gameObject.SetActive(visable);

        profiles.Arrow.gameObject.SetActive(false);
    }

    IEnumerator Ontyping()
    {
        int index = 0;

        isTyping = true;
        while (index < dialogues[currentDialogueIndex].DialogueComData.Length)
        {
            proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData.Substring(0, index+1);

            index++;

            yield return new WaitForSeconds(typingspd);
        }
        isTyping = false;
        proflie[currentCharIndex].Arrow.gameObject.SetActive(true);
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

    [Header("대화")]
    [TextArea(3, 5)]
    public string DialogueComData;
}




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
    [Header("�̸�")]
    public string name;

    [Header("ĳ���� ���� �̹���")]
    public SpriteRenderer CharacterSprite;
    [Header("ĳ���� ���� ���")]
    public Sprite[] CharacterEmotion;

    [Header("��ȭâ �̹���")]
    public Image dialoguePanel;
    [Header("�÷��̾� �̸� ��� �ؽ�Ʈ")]
    public Text nameText;
    [Header("�÷��̾� ��ȭ ��� �ؽ�Ʈ")]
    public Text dialgoueText;

    [Header("������Ʈ�� �������� �˷��ִ� �̹���")]
    public Image Arrow;

}

[System.Serializable]
public struct Dialogue
{
    [Header("��� �� ĳ���� �ѹ���")]
    public int CharacterNum;

    [Header("�ش� ĳ���� ���� ������ȣ")]
    public int Emotion;

    [Header("��ȭ")]
    [TextArea(3, 5)]
    public string DialogueComData;
}




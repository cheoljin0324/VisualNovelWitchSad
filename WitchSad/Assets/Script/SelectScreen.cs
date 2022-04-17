using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScreen : MonoBehaviour
{

    public bool inSelect=false;
    public int SelectNum;

    [Header("선택지")]
    public string[] selectionText;

    [Header("버튼 그룹")]
    public GameObject[] buttonGroup;

    [Header("버튼 지정1")]
    [SerializeField]
    public Text[] FselectionButton;

    [Header("버튼 지정2")]
    [SerializeField]
    public Text[] SselectionButton;

    [Header("버튼 지정3")]
    [SerializeField]
    public Text[] TselectionButton;

    //몇번째 선택지 인가?
    private int currentSelectNum=0;

    public void InstButton()
    {
        if (selectionText.Length == 1)
        {
            buttonGroup[0].gameObject.SetActive(true);
            SelectionSet(1);
        }
        else if (selectionText.Length == 2)
        {
            buttonGroup[1].gameObject.SetActive(true);
            SelectionSet(2);
        }
        else if (selectionText.Length == 3)
        {
            buttonGroup[2].gameObject.SetActive(true);
            SelectionSet(3);
        }
    }

    private void SelectionSet(int selectNum)
    {
        for(int i = 0; i>=selectNum; i++)
        {
            if (selectNum == 1)
            {
                FselectionButton[i].text = selectionText[i].ToString();
            }
            else if(selectNum == 2)
            {
                SselectionButton[i].text = selectionText[i].ToString();
            }
            else if(selectNum == 3)
            {
                TselectionButton[i].text = selectionText[i].ToString();
            }
        }
    }

    public void SetF()
    {
        inSelect = true;
        Debug.Log(1);
        if (selectionText.Length == 1)
        {
            buttonGroup[0].gameObject.SetActive(false);

        }
        else if (selectionText.Length == 2)
        {
            buttonGroup[1].gameObject.SetActive(false);

        }
        else if (selectionText.Length == 3)
        {
            buttonGroup[2].gameObject.SetActive(false);

        }
        SelectNum = 1;
    }
    
    public void SetS()
    {
        inSelect = true;
        Debug.Log(1);
        if (selectionText.Length == 1)
        {
            buttonGroup[0].gameObject.SetActive(false);

        }
        else if (selectionText.Length == 2)
        {
            buttonGroup[1].gameObject.SetActive(false);

        }
        else if (selectionText.Length == 3)
        {
            buttonGroup[2].gameObject.SetActive(false);

        }
        SelectNum = 2;
    }

    public void SetT()
    {
        inSelect = true;
        Debug.Log(1);
        if (selectionText.Length == 1)
        {
            buttonGroup[0].gameObject.SetActive(false);

        }
        else if (selectionText.Length == 2)
        {
            buttonGroup[1].gameObject.SetActive(false);

        }
        else if (selectionText.Length == 3)
        {
            buttonGroup[2].gameObject.SetActive(false);

        }
        SelectNum = 3;
    }


}


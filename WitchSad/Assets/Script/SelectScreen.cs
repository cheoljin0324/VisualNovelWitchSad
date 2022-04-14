using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScreen : MonoBehaviour
{
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

    public bool InstButton()
    {
        if (selectionText.Length == 1)
        {
            buttonGroup[0].gameObject.SetActive(true);
            SelectionSet(1);
            return true;
        }
        else if (selectionText.Length == 2)
        {
            buttonGroup[1].gameObject.SetActive(true);
            SelectionSet(2);
            return true;
        }
        else if (selectionText.Length == 3)
        {
            buttonGroup[2].gameObject.SetActive(true);
            SelectionSet(3);
            return true;
        }

        return false;
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

    public int SetF()
    {
        return 1;
    }
    
    public int SetS()
    {
        return 2;
    }

    public int SetT()
    {
        return 3;
    }


}

public struct Selection
{


}

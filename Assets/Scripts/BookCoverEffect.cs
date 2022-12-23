using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCoverEffect : MonoBehaviour
{
    public GameObject[] talkBubble;
    void Start()
    {
        TalkBubbleActive(false);                //��ǳ�� ����
        StartCoroutine(TalkBubble());      //���ʷ� ���ֱ�
    }
    IEnumerator TalkBubble()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < talkBubble.Length; i++)
        {
            talkBubble[i].SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }
    }
    void TalkBubbleActive(bool active)
    {
        for (int i = 0; i < talkBubble.Length; i++)
        {
            talkBubble[i].SetActive(active);
        }
    }
}

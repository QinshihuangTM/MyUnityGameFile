using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TimedTextHider : MonoBehaviour
{
    public GameObject textObject;

    public Button StartBattleButton;

    void Start()
    {
        textObject.SetActive(false);
        StartBattleButton.onClick.AddListener(isClick);
    }

    public void isClick()
    {
        textObject.SetActive(true);
        StartCoroutine(HideAfterDelay(5.0f));
    }

    IEnumerator HideAfterDelay(float delay)
    {
        // 显示对象（确保它一开始是激活的）
        textObject.SetActive(true);

        // 等待 delay 秒
        yield return new WaitForSeconds(delay);

        // 隐藏对象
        textObject.SetActive(false);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintUIManager : MonoBehaviour
{
    public static HintUIManager Instance;

    public GameObject hintPanel;
    public TextMeshProUGUI hintText;
    public float showDuration = 1.1f;

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
            Destroy(gameObject);

        if(hintPanel != null)
            hintPanel.SetActive(false);
    }

    public void ShowHint(string message)
    {
        if(hintPanel == null || hintText == null) return;

        hintText.text = message;
        hintPanel.SetActive(true);

        CancelInvoke(nameof(HideHint));
        Invoke(nameof(HideHint),showDuration);
    }

    public void HideHint()
    {
        if(hintPanel != null)
            hintPanel.SetActive(false);
    }
}

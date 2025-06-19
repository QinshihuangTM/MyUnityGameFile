using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CoinFarmManager : MonoBehaviour
{
    public GameObject coinFarmPanel;
    public RectTransform coinArea;//金币生成的区域
    public GameObject coinPrefab;
    public Button backButton;

    private bool hasGeneratedCoins = false;

    void Start()
    {
        backButton.onClick.AddListener(BackToPersonalScene);
        OpenPanel();
    }

    public void BackToPersonalScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenPanel()
    {
        coinFarmPanel.SetActive(true);
        if(!hasGeneratedCoins )
        {
            GenerateCoins();
            hasGeneratedCoins = true;
        }
    }

    public void GenerateCoins()
    {
        int coinCount = Random.Range(5, 13);
        Vector2 areaSize = coinArea.rect.size;

        for(int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, coinArea);
            RectTransform coinRT = coin.GetComponent<RectTransform>();

            //计算随机坐标（以锚点中心为原点）
            float x = Random.Range(-areaSize.x / 2f + 50, areaSize.x / 2f - 50);
            float y = Random.Range(-areaSize.y / 2f + 50, areaSize.y / 2f - 50);

            coinRT.anchoredPosition = new Vector2(x, y);

            coinRT.DOAnchorPosY(coinRT.anchoredPosition.y + 10f, 0.3f)
              .SetLoops(-1, LoopType.Yoyo)
              .SetEase(Ease.InOutSine);
        }
    }

}

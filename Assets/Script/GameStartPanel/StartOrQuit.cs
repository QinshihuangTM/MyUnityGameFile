using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.IO;

public class StartOrQuit : MonoBehaviour
{
    //记录需要销毁的物体（即只显示一次，后续再开启游戏后也不会再显示了）
    public GameObject OnlyShowOnce_1;

    //基础类
    public Button button_StartGame;
    public Button button_QuitGame;
    public Button button_CleanData;
    
    //设置类
    public Button button_Setting;

    //更新类
    public Button button_VersionCheck;
    public TextMeshProUGUI VersionText;
    public GameObject Version_Panel;
    public Button versionPanel_CloseButton;

    private void Start()
    {
        button_StartGame.onClick.AddListener(StartGame);
        button_QuitGame.onClick.AddListener(QuitGame);
        button_CleanData.onClick.AddListener(DeleteAllData);
        button_VersionCheck.onClick.AddListener(CheckVersion);
        versionPanel_CloseButton.onClick.AddListener(CloseVersionPanel);
        VersionText.text = "当前版本：beta 2.0";

        //检查需要被销毁的物体是否已消除：
        if (PlayerPrefs.GetInt("OnlyShowOnce_1Destroyed", 0) == 1)
        {
            Destroy(OnlyShowOnce_1.gameObject); // 已销毁过，不再出现
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #endif
    }

    public void DeleteAllData()
    {
        string savePath = Application.persistentDataPath + "/backpack.json";
        if(File.Exists(savePath))
        {
            File.Delete(savePath);
            CoinManager.Instance.currentCoins = 0;
            Debug.Log("存档已删除");
        }
        else
        {
            Debug.Log("未找到任何已存在的存档");
        }
    }

    public void CheckVersion()
    {
        Version_Panel.SetActive(true);

        Destroy(OnlyShowOnce_1.gameObject);
        PlayerPrefs.SetInt("OnlyShowOnce_1Destroyed", 1);
        PlayerPrefs.Save();
    }

    public void CloseVersionPanel()
    {
        Version_Panel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager() { }
    private static GameManager instance;

    [SerializeField]
    public enum Level
    {
        Easy = 1, Normal = 2, Hard = 4
    }

    private static bool _isPause = false;
    private static Level _currentLevel = Level.Easy;
    private static GameObject _player;
    public static bool IsGame { get; set; } = false;
    public static bool IsStop { get { return Time.timeScale > 0 ? true : false; } }
    public static bool IsPause { get { return _isPause; } set{ _isPause = value;} }
    public static int IntLevel { get {return (int)_currentLevel;} set { _currentLevel = (Level)value; } }
    
    public static GameObject PlayerObject { get => _player; }
    public static GameManager Instance
    {
        get
        {
            // GameManager 오브젝트가 없을시 null 반환
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    [SerializeField] private GameObject m_uiManager;
    [SerializeField] private GameObject m_player;

    private void Awake()
    {
        Time.timeScale = 0;
        if (instance)
        {
            // hierarchy에 GameManager 오브젝트가 존재 하는 경우 이 오브젝트 파괴
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        // GameManager 오브젝트는 Scene이 변경되어도 존재
        DontDestroyOnLoad(this.gameObject);

        Instantiate(m_uiManager);
        _player = Instantiate(m_player);
        PlayerObject.SetActive(false);
        UiManager.Instance.AddListnerEvent(UiManager.Buttons.StartBtn, OnClickStartBtn);
        UiManager.Instance.AddListnerEvent(UiManager.Buttons.ExitBtn, OnClickExitBtn);
    }
    void Update()
    {
        // ESC키 누를 시 게임 일시정지 단, 게임이 진행중일 경우
        if (Input.GetKeyDown(KeyCode.Escape) && IsGame)
        {
            GameStop(IsPause);
        }
        UiManager.Instance.DistanceUpdate();
    }
    public void GameReset(bool objectActive)
    {
        Debug.Log($"Step1");
        UiManager.Instance.textUi.SetActive(objectActive);

        Debug.Log($"Step2");
        UiManager.Instance.formButton.SetActive(objectActive);

        Debug.Log($"Step3");
        UiManager.Instance.ExitBtnText();

        Debug.Log($"Step4");
        UiManager.Instance.InitText();

        Debug.Log($"Step5");
        Player.Instance.InitPlayer();

        Debug.Log($"Step6");
        Gauge.GaugeReset();

        Debug.Log($"Step7");
        PlayerObject.SetActive(objectActive);
    }
    public void OnClickStartBtn()
    {
        IsGame = true;
        
        UiManager.Instance.gameMenu.SetActive(false);
        GameReset(true);
        SceneManager.LoadScene("InGame");
        Time.timeScale = 1;
    }

    public void GameStop(bool isPause)
    {
        Time.timeScale = Convert.ToInt32(isPause);
        IsPause = !isPause;
        UiManager.Instance.gameMenu.SetActive(!isPause);
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        IsGame = false;
        UiManager.Instance.ExitBtnText();
        UiManager.Instance.gameMenu.SetActive(true);
        UiManager.Instance.GameMenuTitle();
    }

    public void OnClickExitBtn()
    {
        if (SceneManager.GetActiveScene().name == "GameLobby")
        {
            // 실행 프로그램에 따라 다른 종료 방법
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            GameReset(false);
            SceneManager.LoadScene("GameLobby");
        }

    }
    public void Setting(bool enableOption)
    {
        UiManager.Instance.option.SetActive(enableOption);
        UiManager.Instance.gameMenu.SetActive(!enableOption);
    }
}

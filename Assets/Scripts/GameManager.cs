﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager() { }
    private static GameManager instance;

    [SerializeField]
    public bool gameEasy;
    [SerializeField]
    public bool gameNomal;
    [SerializeField]
    public bool gameHard;
    [HideInInspector]
    public bool isGame;
    private bool isSetting = false;

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
    private void Awake()
    {
        if (instance)
        {
            // hierarchy에 GameManager 오브젝트가 존재 하는 경우 이 오브젝트 파괴
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        // GameManager 오브젝트는 Scene이 변경되어도 존재
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        // ESC키 누를 시 게임 일시정지 단, 게임이 진행중일 경우
        if (Input.GetKeyDown(KeyCode.Escape) && isGame)
        {
            GameStop();
        }
    }

    public void OnClickStartBtn()
    {
        isGame = true;
        UiManager.Instance.gameMenu.SetActive(false);
        UiManager.Instance.textUi.SetActive(true);
        UiManager.Instance.InitText();
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void GameStop()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            UiManager.Instance.gameMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            UiManager.Instance.gameMenu.SetActive(false);
        }
    }

    public void GameEnd()
    {
        isGame = false;
        Time.timeScale = 0;
        UiManager.Instance.gameMenu.SetActive(true);
        UiManager.Instance.GameMenuTitle();
    }

    public void OnClickExitBtn()
    {
        if (SceneManager.GetActiveScene().name == "GameMenuScene")
        {
            // 실행 프로그램에 따라 다른 종료 방법
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            UiManager.Instance.InitText();
            UiManager.Instance.textUi.SetActive(false);
            SceneManager.LoadScene("GameMenuScene");
        }
       
    }
    public void DifficultyEasy()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") return;
        gameEasy = true;
        gameNomal = false;
        gameHard = false;
        UiManager.Instance.DifficultyText();
    }

    public void DifficultyNomal()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") return;
        gameEasy = false;
        gameNomal = true;
        gameHard = false;
        BombGenerator.bombPer = 250;
        BoardGenerator.boardPer = 25;
        UiManager.Instance.DifficultyText();
    }
    public void DifficultyHard()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") return;
        gameEasy = false;
        gameNomal = false;
        gameHard = true;
        BombGenerator.bombPer = 125;
        BoardGenerator.boardPer = 13;
        UiManager.Instance.DifficultyText();
    }
    public void Setting()
    {
        if (isSetting)
        {
            UiManager.Instance.option.SetActive(false);
            UiManager.Instance.gameMenu.SetActive(true);
            isSetting = false;
        }
        else
        {
            UiManager.Instance.option.SetActive(true);
            UiManager.Instance.gameMenu.SetActive(false);
            isSetting = true;
        }
    }
}
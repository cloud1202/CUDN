using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UiManager : UI_Base
{
    private UiManager() { }
    private static UiManager instance;

    [HideInInspector]
    public GameObject gameMenu, option, textUi;

    // UI 이름 열거형으로 저장
    enum GameObjects { GameMenu, Option, TextUI }
    enum Texts { MenuTitleTxt, StartTxt, OptionTxt, ExitTxt, DifficultyTxt, EasyTxt, NomalTxt, BackTxt, DistanceTxt, ItemEatTxt }
    public static UiManager Instance
    {
        get
        {
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

    private void Start()
    {
        // hierarchy에 이름과 동일한 오브젝트 찾아서 저장
        base.Bind<GameObject>(typeof(GameObjects));
        base.Bind<TextMeshProUGUI>(typeof(Texts));

        gameMenu = base.Get<GameObject>((int)GameObjects.GameMenu);
        option = base.Get<GameObject>((int)GameObjects.Option);
        textUi = base.Get<GameObject>((int)GameObjects.TextUI);

        option.SetActive(false);
        textUi.SetActive(false);
    }


    public void DifficultyText()
    {
        // 난이도 Text 표시
        if (GameManager.Instance.gameEasy) base.Get<TextMeshProUGUI>((int)Texts.DifficultyTxt).text = "Difficulty (Easy)";
        else if (GameManager.Instance.gameNomal) base.Get<TextMeshProUGUI>((int)Texts.DifficultyTxt).text = "Difficulty (Nomal)";
        else if (GameManager.Instance.gameHard) base.Get<TextMeshProUGUI>((int)Texts.DifficultyTxt).text = "Difficulty (Hard)";
    }

    public void InitText()
    {
        // 게임 진행 시 올라가는 점수 UI Text 초기화
        base.Get<TextMeshProUGUI>((int)Texts.ItemEatTxt).GetComponent<ScoreText>().InitItem();
        base.Get<TextMeshProUGUI>((int)Texts.DistanceTxt).GetComponent<DistanceText>().InitDistance();
        base.Get<TextMeshProUGUI>((int)Texts.MenuTitleTxt).text = "Game Menu";
    }
    public void GameMenuTitle()
    {
        // 게임 메뉴 타이틀 스코어 전환
        int score = base.Get<TextMeshProUGUI>((int)Texts.ItemEatTxt).GetComponent<ScoreText>().itemEat + (int)(Mathf.Round(base.Get<TextMeshProUGUI>((int)Texts.DistanceTxt).GetComponent<DistanceText>().distance) * 0.1);
        base.Get<TextMeshProUGUI>((int)Texts.MenuTitleTxt).text = "Score : " + score; 
    }

    public void ScoreUpdate()
    {
        // 스코어 Text 업데이트
        base.Get<TextMeshProUGUI>((int)Texts.ItemEatTxt).GetComponent<ScoreText>().ItemUpdate();
    }
    public void DistanceUpdate()
    {
        // 거리 Text 업데이트
        base.Get<TextMeshProUGUI>((int)Texts.DistanceTxt).GetComponent<DistanceText>().DistanceUpdate();
    }
    
}
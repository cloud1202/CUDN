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
    public GameObject gameMenu, option, textUi, formButton;
    [HideInInspector]
    public Button StartBtn, ExitBtn;
    [HideInInspector]
    public Image GaugeImage;
    // UI 이름 열거형으로 저장
    enum GameObjects { GameMenu, Option, TextUI, FormButton, EatterCoolDown, DefenderCoolDown, JumperCoolDown, BoosterCoolDown }
    enum Buttons { StartBtn, OptionBtn, ExitBtn, Eatter, Defender, Jumper, Booster }
    enum Images { Gauge}
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
        base.Bind<Button>(typeof(Buttons));
        base.Bind<TextMeshProUGUI>(typeof(Texts));
        base.Bind<Image>(typeof(Images));

        base.Get<GameObject>((int)GameObjects.EatterCoolDown).SetActive(false);
        base.Get<GameObject>((int)GameObjects.DefenderCoolDown).SetActive(false);
        base.Get<GameObject>((int)GameObjects.JumperCoolDown).SetActive(false);
        base.Get<GameObject>((int)GameObjects.BoosterCoolDown).SetActive(false);

        gameMenu = base.Get<GameObject>((int)GameObjects.GameMenu);
        option = base.Get<GameObject>((int)GameObjects.Option);
        textUi = base.Get<GameObject>((int)GameObjects.TextUI);
        formButton = base.Get<GameObject>((int)GameObjects.FormButton);

        StartBtn = base.Get<Button>((int)Buttons.StartBtn);
        ExitBtn = base.Get<Button>((int)Buttons.ExitBtn);

        GaugeImage = base.Get<Image>((int)Images.Gauge);

        option.SetActive(false);
        textUi.SetActive(false);
        formButton.SetActive(false);
    }

    public void DifficultyText(string LevelName)
    {
        // 난이도 Text 표시
        base.Get<TextMeshProUGUI>((int)Texts.DifficultyTxt).text = $"Difficulty ({LevelName})";
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

    public void ExitBtnText()
    {
        if (base.Get<TextMeshProUGUI>((int)Texts.ExitTxt).text == "Exit")
        {
            base.Get<TextMeshProUGUI>((int)Texts.ExitTxt).text = "Menu";
        }
        else
        {
            base.Get<TextMeshProUGUI>((int)Texts.ExitTxt).text = "Exit";
        }
    }


    //쿨다운 활성화
    public void CoolDownActivation(GameObject ability)
    {
        GameObject selectAbility = base.Get<GameObject>((int)Enum.Parse(typeof(GameObjects), ability.name + "CoolDown"));
        selectAbility.SetActive(true);
    }

    public void CoolDownTimeUpdate(GameObject ability, float coolDownTime)
    {
        GameObject selectAbility = base.Get<GameObject>((int)Enum.Parse(typeof(GameObjects), ability.name+"CoolDown"));
        selectAbility.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{coolDownTime:F1}";
    }
    public void CoolDownDisable(GameObject ability)
    {
        GameObject selectAbility = base.Get<GameObject>((int)Enum.Parse(typeof(GameObjects), ability.name + "CoolDown"));
        selectAbility.SetActive(false);
    }

}
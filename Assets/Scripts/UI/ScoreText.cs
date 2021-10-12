using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [HideInInspector]
    private TextMeshProUGUI itemEatTxt;
    public int itemEat = 0;
    // 현제 폰트 사이즈에 맞는 최대 아이템 먹은 갯수
    private int textSizeChangeVolume = 100;
    private void Awake()
    {
        itemEatTxt = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void ItemUpdate()
    {
        itemEat += 1;
        if (itemEat >= textSizeChangeVolume) {
            itemEatTxt.fontSize -= 3;

            // 한번 폰트 변경후 최대 갯수 변경
            textSizeChangeVolume *= 10;
        }
        itemEatTxt.text = itemEat + "";
    }
    public void InitItem()
    {
        itemEat = 0;
        itemEatTxt.text = "0";
    }
}

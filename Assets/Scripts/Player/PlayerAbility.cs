using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [HideInInspector]
    public static GameObject absorption;

    private void Awake()
    {
        absorption = transform.Find("Absorption").gameObject;
    }

    public void ClickAbility(GameObject ability)
    {
        if (Player.ability == ability.name || Player.isBoost) { return; }

        if(ability.name == "Booster" && !Player.isBoosterGauge) { return; }
        Player.ability = ability.name;
        float coolDownTime = 1.0f;
        AbilityCoolDown.instance.CoolDownEnable(ability, coolDownTime);

    }
    public void Eatter()
    {
        if (Player.isBoost) { return; }
        Player.maxJump = 1;
        Player.isAbsorption = true; 
        Player.isDefence = false;
        absorption.SetActive(true);
    }
    public void Defender()
    {
        if (Player.isBoost) { return; }
        Player.maxJump = 1;
        Player.isDefence = true;
        absorption.SetActive(false);
    }
    public void Jumper()
    {
        if (Player.isBoost) { return; }
        Player.maxJump = 2;
        Player.isDefence = false;
        absorption.SetActive(false);
    }
    public void Booster()
    {
        if (Player.isBoosterGauge)
        {
            Player.playerRb.useGravity = false;
            Player.isBoost = true;
            Time.timeScale = 2;
            UiManager.Instance.BoosterGaugeEmpty();
            Player.isDefence = true;
            absorption.SetActive(true);
        }
        else
        {
            Debug.Log("게이지가 덜참");
        }
    }
}

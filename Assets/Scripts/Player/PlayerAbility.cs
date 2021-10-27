using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [HideInInspector]
    public static Player player;
    [HideInInspector]
    public static GameObject absorption;
    private void Awake()
    {
        player = GetComponent<Player>();
        absorption = transform.Find("Absorption").gameObject;
    }

    public void ClickAbility(GameObject ability)
    {
        if (player.ability == ability.name) { return; }
        float coolDownTime = 1.0f;
        player.ability = ability.name;
        AbilityCoolDown.instance.CoolDownEnable(ability, coolDownTime);

    }
    public void Eatter()
    {
        player.maxJump = 1;
        player.isAbsorption = true;
        absorption.SetActive(true);
    }
    public void Defender()
    {
        player.maxJump = 1;
        absorption.SetActive(false);
    }
    public void Jumper()
    {
        player.maxJump = 2;
        absorption.SetActive(false);
    }
    public void Booster()
    {
        player.maxJump = 1;
        absorption.SetActive(false);
    }
}

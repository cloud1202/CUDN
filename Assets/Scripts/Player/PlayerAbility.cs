using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void ClickAbility(GameObject ability)
    {
        float coolDownTime = 1.0f;
        AbilityCoolDown.instance.CoolDownEnable(ability, coolDownTime);

    }
    public void Eatter()
    {
        Debug.Log(player);
        transform.Find("Absorption").gameObject.SetActive(true);
    }
    public void Defender()
    {
        Debug.Log("def");
        transform.Find("Absorption").gameObject.SetActive(false);
    }
    public void Jumper()
    {
        Debug.Log("jump");
        transform.Find("Absorption").gameObject.SetActive(false);
    }
    public void Booster()
    {
        Debug.Log("boost");
        transform.Find("Absorption").gameObject.SetActive(false);
    }
}

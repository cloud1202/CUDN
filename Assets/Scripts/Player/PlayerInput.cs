using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private Camera Camera { get { return GameObject.Find("Main Camera").GetComponent<Camera>(); } }
    private Vector3 touchPos;

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (Input.GetMouseButtonDown(0) && (Player.jumpCount > 0) && !Player.IsBoost)
        {
            Player.Instance.PlayerJump();
        }
        else if(Player.IsBoost)
        {
            touchPos = Input.GetMouseButton(0) ? Camera.ScreenToWorldPoint(Input.mousePosition) : Player.lastTouchPos;
            Player.Instance.PlayerVerticalMove(touchPos);
        }
    }
}

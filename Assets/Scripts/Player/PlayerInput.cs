using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    Player player;
    Camera Camera;
    Vector3 touchPos;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GetComponent<Player>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (Input.GetMouseButtonDown(0) && (player.jumpCount > 0) && !Player.isBoost)
        {
            player.PlayerJump();
        }
        else if(Player.isBoost)
        {
            touchPos = Input.GetMouseButton(0) ? Camera.ScreenToWorldPoint(Input.mousePosition) : Player.lastTouchPos;
            player.PlayerVerticalMove(touchPos);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (player.jumpCount > 0))
        {
            player.PlayerJump();
        }

        UiManager.Instance.DistanceUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Rigidbody playerRb;
    Animator playerAnime;
    Vector3 playerPos;
  
    // player status
    [HideInInspector]
    public static bool isDefence = false;
    [HideInInspector]
    public static int maxJump = 1;
    [HideInInspector]
    public static bool isAbsorption = true;
    [HideInInspector]
    public static bool isBoosterGauge = false;
    [HideInInspector]
    public static bool isBoost = false;
    // 기본 능력 -> [흡입 능력]
    [HideInInspector]
    public static string ability = "Eatter";

    float speed = 50000.0f;
    //
    public static Vector3 lastTouchPos;
    [HideInInspector]
    public int jumpCount;
    [HideInInspector]
    public static bool isJump;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnime = GetComponent<Animator>();
        playerPos = gameObject.transform.position;
        jumpCount = maxJump;
        lastTouchPos = transform.position;
    }

    public void PlayerJump()
    {
        playerAnime.SetBool("isJump", true);
        playerRb.AddForce(gameObject.transform.up * speed);
        jumpCount -= 1;
        isJump = true;
    }
    public void PlayerVerticalMove(Vector3 touchPos)
    {
        lastTouchPos = touchPos;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, touchPos.y, transform.position.z), 13 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿으면 점프 가능
        if (collision.gameObject.tag == "Board")
        {
            playerAnime.SetBool("isJump", false);
            jumpCount = maxJump;
            isJump = false;
        }

        // 떨어지는 중 센서에 닿으면 게임 끝
        if (collision.gameObject.name == "PlayerDestroySensor")
        {
            GameManager.Instance.GameEnd();
        }
    }

}

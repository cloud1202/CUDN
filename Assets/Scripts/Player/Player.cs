using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnime;

  
    // player status
    [HideInInspector]
    public float defence = 0;
    [HideInInspector]
    public int maxJump = 1;
    [HideInInspector]
    public bool isAbsorption;
    [HideInInspector]
    public string  ability;

    float speed = 50000.0f;
    //

    [HideInInspector]
    public int jumpCount;
    [HideInInspector]
    public bool isJump;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnime = GetComponent<Animator>();
        jumpCount = maxJump;
    }

    public void PlayerJump()
    {
        playerAnime.SetBool("isJump", true);
        playerRb.AddForce(gameObject.transform.up * speed);
        jumpCount -= 1;
        isJump = true;
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

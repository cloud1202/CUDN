using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnime;
    [HideInInspector]
    public GameObject player;
    float speed = 50000.0f;
    Vector3 firstTap, gap;
    int isSpace = 2;

    void Awake()
    {
        player = this.gameObject;
        playerRb = GetComponent<Rigidbody>();
        playerAnime = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isSpace > 0))
        {
            PlayerJump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            firstTap = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            gap = Input.mousePosition - firstTap;

            // 움직인 거리가 짧으면 리턴
            if (gap.magnitude < 20) return;
            gap.Normalize();
        }

        UiManager.Instance.DistanceUpdate();
    }

    void PlayerJump()
    {
        playerAnime.SetBool("isJump", true);
        playerRb.AddForce(gameObject.transform.up * speed);
        isSpace -= 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿으면 점프 가능
        if (collision.gameObject.tag == "Board")
        {
            playerAnime.SetBool("isJump", false);
            isSpace = 2;
        }

        // 떨어지는 중 센서에 닿으면 게임 끝
        if(collision.gameObject.name == "PlayerDestroySensor")
        {
            GameManager.Instance.GameEnd();
        }
    }
    void FormChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 firstPos = Input.mousePosition;
        }
    }
}

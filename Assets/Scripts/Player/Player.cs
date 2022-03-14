using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Player() { }
    private static Player instance;

    public Rigidbody PlayerRb { get; private set; }
    public Animator PlayerAnime { get; private set; }
    public Vector3 PlayerPos { get; private set; }

    // player status
    [HideInInspector]
    public static bool IsDefence { get { return ability.Equals("Defender") || Player.IsBoost ? true : false; } }
    [HideInInspector]
    public static int maxJump { get { return ability.Equals("Jumper") ? 2 : 1; } }
    public static bool IsAbsorption { get { return ability.Equals("Eatter") || Player.IsBoost ? true : false; } }
    [HideInInspector]
    public static bool IsBoost { get { return !Player.Instance.PlayerRb.useGravity; } }

    // 기본 능력 -> [흡입 능력]
    [HideInInspector]
    public static string ability = "Eatter";

    private static float speed;
    //
    public static Vector3 lastTouchPos;
    [HideInInspector]
    public static int jumpCount;
    [HideInInspector]
    public static bool isJump;

    public static Player Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerAnime = GetComponent<Animator>();
        PlayerPos = gameObject.transform.position;
        speed = 1000.0f;
        InitPlayer();
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void InitPlayer()
    {
        transform.position = PlayerPos;
        lastTouchPos = transform.position;
        PlayerRb.velocity = Vector3.zero;
        jumpCount = maxJump;
        ability = "Eatter";
    }
    public void PlayerJump()
    {
        PlayerAnime.SetBool("isJump", true);
        Transform groundTransform = transform;
        PlayerRb.AddForce(transform.up * speed, ForceMode.Impulse);
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
            PlayerAnime.SetBool("isJump", false);
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

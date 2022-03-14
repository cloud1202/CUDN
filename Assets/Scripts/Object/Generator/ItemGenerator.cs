using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemGenerator : GeneratorManager<HorizontalMove>
{
    public static ItemGenerator instance;

    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private GameObject coinPrefab;

    Queue<CoinMove> coinQueue = new Queue<CoinMove>();
    Queue<BombMove> bombQueue = new Queue<BombMove>();
    static int maxBomb = 5;
    static int maxCoin = 40;

    public static bool isBomb;
    public static int bombPer = 500;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GeneratorManager<BombMove>.Instance.Initialize(bombQueue, maxBomb, bombPrefab, instance.transform);
        GeneratorManager<CoinMove>.Instance.Initialize(coinQueue, maxCoin, coinPrefab, instance.transform);
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            isBomb = Random.Range(0, bombPer) > 0 ? false : true;
            
            if (isBomb)
            {
                GeneratorManager<BombMove>.Instance.GetObject(bombQueue, bombPrefab, instance.transform).transform.position = transform.position;
            }
            else if (!isBomb)
            {
                GeneratorManager<CoinMove>.Instance.GetObject(coinQueue, coinPrefab, instance.transform).transform.position = transform.position;
            }
        }

    }
    public static void objectDestroy(CoinMove obj)
    {
        GeneratorManager<CoinMove>.Instance.ReturnObject(obj, instance.coinQueue, instance.transform);
    }
    public static void objectDestroy(BombMove obj)
    {
        GeneratorManager<BombMove>.Instance.ReturnObject(obj, instance.bombQueue, instance.transform);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : GeneratorManager<CoinMove>
{
    private static CoinGenerator instance;

    [SerializeField]
    private GameObject coinPrefab;
    
    Queue<CoinMove> coinQueue = new Queue<CoinMove>();
    static int maxCoin = 40;

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        GeneratorManager<CoinMove>.Instance.Initialize(coinQueue, maxCoin, coinPrefab, instance.transform);
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (!BombGenerator.isBomb)
            {
                var obj = GeneratorManager<CoinMove>.Instance.GetObject(coinQueue, coinPrefab, instance.transform);
                obj.transform.position = transform.position;
            }
        }

    }
    public static void objectDestroy(CoinMove obj)
    {
        GeneratorManager<CoinMove>.Instance.ReturnObject(obj, instance.coinQueue, instance.transform);
    }

}

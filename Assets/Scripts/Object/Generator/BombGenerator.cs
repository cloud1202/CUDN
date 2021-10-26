using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : GeneratorManager<BombMove>
{
    public static BombGenerator instance;
    [SerializeField]
    private GameObject bombPrefab;

    Queue<BombMove> bombQueue = new Queue<BombMove>();
    static int maxBomb = 5;
    public static bool isBomb;
    public static int bombPer = 500;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GeneratorManager<BombMove>.Instance.Initialize(bombQueue, maxBomb, bombPrefab, instance.transform);
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        isBomb = Random.Range(0, bombPer) > 0 ? false : true;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (isBomb)
            {
                var obj = GeneratorManager<BombMove>.Instance.GetObject(bombQueue, bombPrefab, instance.transform);
                obj.transform.position = transform.position;
            }
        }

    }
    public static void objectDestroy(BombMove obj)
    {
        GeneratorManager<BombMove>.Instance.ReturnObject(obj, instance.bombQueue, instance.transform);
    }
}

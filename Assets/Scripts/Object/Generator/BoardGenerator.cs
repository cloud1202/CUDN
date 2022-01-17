using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : GeneratorManager<BoardMove>
{
    public static BoardGenerator instance;
    [SerializeField]
    private GameObject boardPrefab;
    Queue<BoardMove> boardQueue = new Queue<BoardMove>();
    static int maxBoard = 40;
    static bool isBoard;
    public static int boardPer = 50;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GeneratorManager<BoardMove>.Instance.Initialize(boardQueue, maxBoard, boardPrefab, instance.transform);
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            //isBoard = Random.Range(0, boardPer) > 0 ? true : false;
            isBoard = true;
            yield return new WaitForSeconds(0.48f);
            if (isBoard)
            {
                var obj = GeneratorManager<BoardMove>.Instance.GetObject(boardQueue, boardPrefab, instance.transform);
                obj.transform.position = transform.position;
            }
        }

    }
    public static void objectDestroy(BoardMove obj)
    {
        GeneratorManager<BoardMove>.Instance.ReturnObject(obj, instance.boardQueue, instance.transform);
    }
}

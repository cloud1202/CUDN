using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager<T>: MonoBehaviour where T : Move
{
    private static GeneratorManager<T> instance;
    public static GeneratorManager<T> Instance
    {
        get
        {
            if (null == instance)
            {
                instance = (GeneratorManager<T>)FindObjectOfType(typeof(GeneratorManager<T>));
                if(null == instance)
                {
                    var generatorManager = new GameObject();
                    instance = generatorManager.AddComponent<GeneratorManager<T>>();

                    DontDestroyOnLoad(generatorManager);
                }
            }
            return instance;
        }
    }
    // 정해진 갯수로 큐 초기화
    public void Initialize(Queue<T> objectQueue, int initCount, GameObject objectPrefab, Transform genenratorTransform)
    {
        for (int count = 0; count < initCount; count++)
        {
            objectQueue.Enqueue(CreateObject(objectPrefab, genenratorTransform));
        }
    }
    // 클론 생성시 받은 부모오브젝트로 부모 설정 후 클론 객체 리턴
    public T CreateObject(GameObject objectPrefab, Transform genenratorTransform)
    {
        var newObject = Instantiate(objectPrefab).GetComponent<Move>();
        newObject.gameObject.SetActive(false);
        newObject.transform.SetParent(genenratorTransform);
        return (T)newObject;
    }

    // 큐에 쌓여진 오브젝트 리턴 없다면 새로운 오브젝트 생성
    public T GetObject(Queue<T> objectQueue, GameObject objectPrefab, Transform genenratorTransform)
    {
        if (objectQueue.Count > 0)
        {
            var obj = objectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObject = CreateObject(objectPrefab, genenratorTransform);
            newObject.gameObject.SetActive(true);
            newObject.transform.SetParent(null);
            return newObject;
        }
    }

    // 사용한 오브젝트 리턴
    public void ReturnObject(T obj, Queue<T> objectQueue, Transform genenratorTransform)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(genenratorTransform);
        objectQueue.Enqueue(obj);
    }
}

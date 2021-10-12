using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();


    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int enumIndex = 0; enumIndex < names.Length; enumIndex++){
            if (typeof(T) == typeof(GameObject)) objects[enumIndex] = Util.FindChild(gameObject, names[enumIndex], true);
            else objects[enumIndex] = Util.FindChild<T>(gameObject, names[enumIndex], true);
        }
    }

    protected T Get<T>(int enumIndex) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false) return null;

        return objects[enumIndex] as T;
    }
}

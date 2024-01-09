using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactPropertySkipOnSubscribe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var health = new ReactiveProperty<int>(100);
        health.SkipLatestValueOnSubscribe().Subscribe(x => Debug.Log("Notified value: " + x));
        health.Value = 50;
        health.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

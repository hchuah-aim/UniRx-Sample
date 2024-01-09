using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ObservableTimer2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timer = Observable.Timer(dueTime: TimeSpan.FromSeconds(1), period: TimeSpan.FromSeconds(0.5));
        
        Debug.Log("Subscribe time: " + Time.time);

        timer.Subscribe(x => Debug.Log($"{x}: {Time.time}"), (() => Debug.Log("OnCompleted"))).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

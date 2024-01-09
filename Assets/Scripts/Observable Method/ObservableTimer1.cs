using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableTimer1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timer = Observable.Timer(dueTime: TimeSpan.FromSeconds(1));
        
        Debug.Log("Subscribed timer: " + Time.time);

        timer.Subscribe(x =>
        {
            Debug.Log("OnNext time: " + Time.time);
            Debug.Log("OnNext: " + x);
        }, () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

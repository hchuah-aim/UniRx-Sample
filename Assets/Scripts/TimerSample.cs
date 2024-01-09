using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

public class TimerSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThread).Subscribe(x => Debug.Log("1 seconds, thread ID: " + Thread.CurrentThread.ManagedThreadId))
            .AddTo(this);

        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(x => Debug.Log("1 seconds, thread ID: " + Thread.CurrentThread.ManagedThreadId)).AddTo(this);

        Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThreadEndOfFrame).Subscribe(x => Debug.Log("1 seconds, thread ID: " + Thread.CurrentThread.ManagedThreadId))
            .AddTo(this);
        
        new Thread(() =>
        {
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.CurrentThread).Subscribe(x =>
                Debug.Log("1 seconds, thread ID: " + Thread.CurrentThread.ManagedThreadId)).AddTo(this);
        }).Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

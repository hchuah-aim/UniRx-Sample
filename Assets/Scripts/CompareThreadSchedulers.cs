using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class CompareThreadSchedulers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(3), Scheduler.MainThread).Subscribe().AddTo(this);
        Observable.Timer(TimeSpan.FromSeconds(3), Scheduler.CurrentThread).Subscribe().AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UniRx;
using UnityEngine;

public class ObservableToAsync1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Func<IObservable<string>> fileReadFunc;

        fileReadFunc = Observable.ToAsync(() =>
        {
            using (var r = new StreamReader(@"data.txt"))
            {
                return r.ReadToEnd();
            }
        }, Scheduler.ThreadPool);

        fileReadFunc().Subscribe(x => Debug.Log(x));
        
        // or
        //fileReadFunc.Invoke().Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

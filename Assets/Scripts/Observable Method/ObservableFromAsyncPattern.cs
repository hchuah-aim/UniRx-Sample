using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UniRx;
using UnityEngine;

public class ObservableFromAsyncPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Func<string, string> readFile = fileName =>
        {
            using (var r = new StreamReader(fileName))
            {
                return r.ReadToEnd();
            }
        };

        Func<string, IObservable<string>> f =
            Observable.FromAsyncPattern<string, string>(readFile.BeginInvoke, readFile.EndInvoke);

        IObservable<string> readAsync = f("data.txt");

        readAsync.Subscribe(Debug.Log);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

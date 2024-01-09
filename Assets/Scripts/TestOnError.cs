using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TestOnError : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<string>();
        subject.Select(str => int.Parse((str))).Subscribe(x => Debug.Log(x), ex => Debug.LogError(ex.Message),
            () => Debug.Log("OnCompleted"));
        
        subject.OnNext("1");
        subject.OnNext("2");
        subject.OnNext("Three");
        subject.OnNext("4");

        subject.Subscribe(x => Debug.Log(x), () => Debug.Log("Completed"));
        subject.OnNext("Hello");
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

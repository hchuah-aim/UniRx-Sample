using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();
        
        subject.OnNext(1);

        subject.Subscribe(x => Debug.Log("OnNext: " + x), ex => Debug.LogError("OnError: " + ex),
            () => Debug.Log("OnCompleted"));
        
        subject.OnNext(2);
        subject.OnNext(3);
        
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReplaySubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new ReplaySubject<int>(bufferSize: 3);

        for (int i = 0; i < 10; i++)
        {
            subject.OnNext(i);
        }
        
        subject.OnCompleted();
        
        //subject.OnError(new Exception("Error!));

        subject.Subscribe(x => Debug.Log("OnNext: " + x), ex => Debug.LogError("OnError: " + ex),
            () => Debug.Log("OnCompleted"));
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

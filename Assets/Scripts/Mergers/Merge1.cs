using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Merge1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var s1 = Observable.Range(10, 3, Scheduler.MainThread);
        var s2 = Observable.Range(20, 3, Scheduler.MainThread);

        s1.Merge(s2).Subscribe(x => Debug.Log($"{Time.frameCount} - {x}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

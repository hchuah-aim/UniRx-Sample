using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableTimerFrame1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timer = Observable.TimerFrame(dueTimeFrameCount: 5);
        
        Debug.Log("Subscribed frame: " + Time.frameCount);

        timer.Subscribe(x =>
        {
            Debug.Log("OnNext frame:" + Time.frameCount);
            Debug.Log("OnNext value: " + x);
        }, () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

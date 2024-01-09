using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ObservableTimerFrame2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timer = Observable.TimerFrame(dueTimeFrameCount: 5, periodFrameCount: 10);
        
        Debug.Log("Subscribed frame: " + Time.frameCount);
        timer.Subscribe(x => Debug.Log($"{x} - {Time.frameCount}"), () => Debug.Log("OnCompleted")).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

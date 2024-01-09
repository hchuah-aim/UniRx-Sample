using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableRangeSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(0, 5).Subscribe(x => Debug.Log("OnNext: " + x), ex => Debug.LogError("OnError: " + ex), () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

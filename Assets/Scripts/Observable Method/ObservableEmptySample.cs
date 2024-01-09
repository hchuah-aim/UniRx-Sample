using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableEmptySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Empty<int>().Subscribe(x => Debug.Log("OnNext: " + x),
            ex => Debug.LogError("OnError: " + ex.Message), () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

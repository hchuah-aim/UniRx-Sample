using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableRepeatSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Repeat("yes", 3).Subscribe(x => Debug.Log("OnNext: " + x), ex => Debug.LogError("OnError: " + ex),
            () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

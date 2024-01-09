using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class IEnumerableToObservable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var strArray = new[] { "apple", "banana", "lemon" };

        strArray.ToObservable().Subscribe(x => Debug.Log("OnNext: " + x),
            ex => Debug.LogError("OnError: " + ex.Message), () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

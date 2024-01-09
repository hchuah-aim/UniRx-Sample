using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableDeferSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rand = Observable.Defer(() =>
        {
            var randomValue = UnityEngine.Random.Range(0, 100);

            return Observable.Return(randomValue);
        });

        rand.Subscribe(x => Debug.Log(x));
        rand.Subscribe(x => Debug.Log(x));
        rand.Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

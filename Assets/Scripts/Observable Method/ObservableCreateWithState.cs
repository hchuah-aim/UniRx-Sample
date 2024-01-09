using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableCreateWithState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateCountObservable(10).Subscribe(x => Debug.Log(x));
    }

    private IObservable<int> CreateCountObservable(int count)
    {
        if (count <= 0) return Observable.Empty<int>();

        return Observable.CreateWithState<int, int>(state: count, subscribe: (maxCount, observer) =>
        {
            for (int i = 0; i < maxCount; i++)
            {
                observer.OnNext(i);
            }

            observer.OnCompleted();
            return Disposable.Empty;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

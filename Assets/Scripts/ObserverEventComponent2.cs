using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObserverEventComponent2 : MonoBehaviour
{
    [SerializeField] private CountDownEventProvider _countDownEventProvider;

    private IDisposable _disposable;
    
    // Start is called before the first frame update
    void Start()
    {
        _disposable = _countDownEventProvider.CountDownObservable.Subscribe(x => Debug.Log(x), ex => Debug.LogError(ex),
            () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void OnDestroy()
    {
        _disposable?.Dispose();
    }
}

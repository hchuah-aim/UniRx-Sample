using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveEventComponent : MonoBehaviour
{
    [SerializeField] private CountDownEventProvider _countDownEventProvider;

    private PrintLogObserver<int> _printLogObserver;

    private IDisposable _disposable;
    
    // Start is called before the first frame update
    void Start()
    {
        _printLogObserver = new PrintLogObserver<int>();
        _disposable = _countDownEventProvider.CountDownObservable.Subscribe(_printLogObserver);
    }
    
    void OnDestroy()
    {
        _disposable?.Dispose();
    }
}

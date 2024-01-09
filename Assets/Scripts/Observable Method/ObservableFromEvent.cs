using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObservableFromEvent : MonoBehaviour
{
    public sealed class MyEventArgs : EventArgs
    {
        public int MyProperty { get; set; }
    }

    private event EventHandler<MyEventArgs> _onEvent;

    private event Action<int> _callBackAction;

    [SerializeField] private Button _uiButton;

    private readonly CompositeDisposable _disposable = new CompositeDisposable();
    
    // Start is called before the first frame update
    void Start()
    {
        // FromEventPattern event
        Observable.FromEventPattern<EventHandler<MyEventArgs>, MyEventArgs>(
                h => h.Invoke,
                h => _onEvent += h,
                h => _onEvent -= h)
            .Subscribe()
            .AddTo(_disposable);
        
        // FromEvent event
        Observable.FromEvent<EventHandler<MyEventArgs>, MyEventArgs>(
            h => (sender, e) => h(e),
            h => _onEvent += h,
            h => _onEvent -= h)
            .Subscribe()
            .AddTo(_disposable);

        // FromEvent Action
        Observable.FromEvent<int>(
                h => _callBackAction += h,
                h => _callBackAction -= h)
            .Subscribe()
            .AddTo(_disposable);
        
        // FromEvent UnityAction
        Observable.FromEvent<UnityAction>(
                h => new UnityAction(h),
                h => _uiButton.onClick.AddListener(h),
                h => _uiButton.onClick.RemoveListener(h))
            .Subscribe()
            .AddTo(_disposable);

        // UnityAction FromEvent => AsObservable
        _uiButton.onClick.AsObservable().Subscribe().AddTo(_disposable);
        
        // UnityAction AsObservable => OnClickAsObservable
        _uiButton.OnClickAsObservable().Subscribe().AddTo(_disposable);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        _disposable.Dispose();
    }
}

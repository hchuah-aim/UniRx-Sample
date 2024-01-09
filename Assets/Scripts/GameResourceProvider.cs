using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameResourceProvider : MonoBehaviour
{
    private readonly AsyncSubject<Texture> _playerTextureAsyncSubject = new AsyncSubject<Texture>();

    public IObservable<Texture> PlayerTextureAsync => _playerTextureAsyncSubject;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadTexture());
    }

    private IEnumerator LoadTexture()
    {
        var resource = Resources.LoadAsync("Textures/player");
        yield return resource;
        
        _playerTextureAsyncSubject.OnNext(resource.asset as Texture);
        _playerTextureAsyncSubject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

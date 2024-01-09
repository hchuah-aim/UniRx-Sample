using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UniRx;
using UnityEngine.Networking;

public class TestUniTask : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    
    // Start is called before the first frame update
    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        SetupTextureAsync(token).Forget();
    }

    private async UniTaskVoid SetupTextureAsync(CancellationToken token)
    {
        try
        {
            var uri = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";

            var observable = Observable.Defer((() => GetTextureAsync(uri, token).ToObservable())).Retry(3);

            var texture = await observable;
            _rawImage.texture = texture;
        }
        catch (Exception e) when (!(e is OperationCanceledException))
        {
            Debug.LogError(e);
        }
    }

    private async UniTask<Texture> GetTextureAsync(string uri, CancellationToken token)
    {
        using (var uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            await uwr.SendWebRequest().WithCancellation(token);
            return ((DownloadHandlerTexture)uwr.downloadHandler).texture;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

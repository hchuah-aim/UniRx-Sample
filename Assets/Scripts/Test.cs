using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.Networking;

public class Test : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    
    // Start is called before the first frame update
    void Start()
    {
        var uri = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";

        GetTextureAsync(uri).OnErrorRetry(
            onError: (Exception _) => { },
            retryCount: 3).Subscribe(result => { _rawImage.texture = result; },
            error => { Debug.LogError(error); }).AddTo(this);
    }

    private IObservable<Texture> GetTextureAsync(string uri)
    {
        return Observable.FromCoroutine<Texture>(observer => GetTextureCoroutine(observer, uri));
    }

    private IEnumerator GetTextureCoroutine(IObserver<Texture> observer, string uri)
    {
        using (var uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError ||
                uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                observer.OnError(new Exception(uwr.error));
                yield break;
            }

            var result = ((DownloadHandlerTexture)uwr.downloadHandler).texture;
            observer.OnNext(result);
            observer.OnCompleted();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

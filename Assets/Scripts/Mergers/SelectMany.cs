using System.Collections;
using System.Collections.Generic;
using System.Net;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SelectMany : MonoBehaviour
{
    [SerializeField] private Button downloadButton;

    private string url = "http://www.google.com";
    // Start is called before the first frame update
    void Start()
    {
        downloadButton.OnClickAsObservable().Select(_ => url).SelectMany(uri => FetchAsync(uri).ToObservable())
            .Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    async UniTask<string> FetchAsync(string uri)
    {
        using (var uwr = UnityWebRequest.Get(uri))
        {
            await uwr.SendWebRequest();
            return uwr.downloadHandler.text;
        }
    }
}

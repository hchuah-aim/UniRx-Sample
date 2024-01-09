using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

public class PlayerTextureChanger : MonoBehaviour
{
    [SerializeField] private GameResourceProvider _gameResourceProvider;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameResourceProvider.PlayerTextureAsync.Subscribe(SetMyTexture).AddTo(this);
    }

    private void SetMyTexture(Texture newTexture)
    {
        var renderer = GetComponent<Renderer>();
        renderer.sharedMaterial.mainTexture = newTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

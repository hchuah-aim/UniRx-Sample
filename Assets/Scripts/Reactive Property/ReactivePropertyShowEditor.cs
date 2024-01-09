using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertyShowEditor : MonoBehaviour
{
    [SerializeField] private ReactiveProperty<int> NoShow;

    [SerializeField] private IntReactiveProperty Show;

    [SerializeField]
    private FruitReactiveProperty fruits;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

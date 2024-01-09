using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChanged : MonoBehaviour
{
    [SerializeField] private Toggle uiToggle;
    // Start is called before the first frame update
    void Start()
    {
        uiToggle.isOn = false;

        uiToggle.onValueChanged.AsObservable().Subscribe(x => Debug.Log("AsObservable: " + x));
        uiToggle.OnValueChangedAsObservable().Subscribe(x => Debug.Log("OnValueChangedAsObservable: " + x));
        
        Debug.Log("---");

        uiToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

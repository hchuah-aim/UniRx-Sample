using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.A)).ThrottleFirstFrame(1000)
            .Subscribe(_ => Debug.Log("Attack"));
    }
    
}

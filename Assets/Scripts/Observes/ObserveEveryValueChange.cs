using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

public class ObserveEveryValueChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.ObserveEveryValueChanged(x => x.position).Subscribe(vec3 => Debug.Log("Position: " + vec3));
        var rigidBody = GetComponent<Rigidbody>();

        rigidBody.ObserveEveryValueChanged(x => x.velocity, FrameCountType.FixedUpdate)
            .Subscribe(vec3 => Debug.Log("Velocity: " + vec3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

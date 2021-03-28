using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float openY;
    public float openSpeed;

    bool _open;

    void FixedUpdate()
    {
        if (_open)
        {
            Vector3 newPos = transform.position;
            newPos.y += openSpeed * Time.deltaTime;
            transform.position = newPos;

            if (transform.localPosition.y >= openY)
                _open = false;
        }
    }

    public void OpenGate()
    {
        Debug.Log("[Gate.cs] - Gate open.");
        _open = true;
    }
}

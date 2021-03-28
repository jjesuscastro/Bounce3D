using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onInteract;
    public virtual void Interact()
    {
        if (onInteract != null)
            onInteract.Invoke();
    }
}

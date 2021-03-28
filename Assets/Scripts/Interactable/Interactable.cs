using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onInteract;
    public AudioClip interactionSound;

    public virtual void Interact()
    {
        if (interactionSound != null)
        {
            AudioSource.PlayClipAtPoint(interactionSound, transform.position);
            Debug.Log("[Interactable.cs] - Audio played");
        }

        if (onInteract != null)
            onInteract.Invoke();
    }
}

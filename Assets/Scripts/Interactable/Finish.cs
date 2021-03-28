using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : Interactable
{
    public override void Interact()
    {
        base.Interact();

        BoxCollider boxCollider = GetComponent<BoxCollider>();

        if (boxCollider != null)
            boxCollider.enabled = false;
    }
}

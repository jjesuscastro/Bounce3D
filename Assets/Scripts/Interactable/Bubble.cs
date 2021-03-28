using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Interactable
{
    public override void Interact()
    {
        base.Interact();

        Destroy(this.gameObject);
    }
}

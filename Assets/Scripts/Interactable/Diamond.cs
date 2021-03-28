using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Interactable
{
    public GameObject arrow;
    public override void Interact()
    {
        base.Interact();

        Instantiate(arrow, transform.position, arrow.transform.rotation, transform.parent);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : Interactable
{
    public MeshRenderer meshRenderer;
    public Material ringDisabledMaterial;
    BoxCollider boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public override void Interact()
    {
        base.Interact();

        meshRenderer.material = ringDisabledMaterial;
        boxCollider.enabled = false;
    }
}

using System;
using UnityEngine;

public class ChestInteract : ObjectInteract
{
    private Animator _chestAnimation;
    [SerializeField] private bool opened = false;

    private void Awake()
    {
        _chestAnimation = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (!opened)
        {
            opened = !opened;
            _chestAnimation.SetBool("open", opened);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : ToolInteract
{
    [SerializeField] private GameObject _itemDropped;
    [SerializeField] private int _qttItemDropped;
    [SerializeField] private float _spreadArea = 0.7f;
    
    public override void Interact()
    {
        while (_qttItemDropped > 0)
        {
            _qttItemDropped -= 1;

            Vector3 position = transform.position;
            position.x += GetRandomValue();
            position.y += GetRandomValue();
            Instantiate(_itemDropped, position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private float GetRandomValue()
    {
        return _spreadArea * Random.value - _spreadArea / 2;
    }
}

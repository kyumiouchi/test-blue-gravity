using UnityEngine;
using UnityEngine.U2D.Animation;

public class WearItem : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private SpriteLibrary _spriteLibrary;
    private Animator _animator;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _spriteLibrary = GetComponent<SpriteLibrary>();
        _animator = GetComponent<Animator>();
    }

    public void UpdateData(ItemDataSo itemDataSo)
    {
        _renderer.enabled = (itemDataSo != null);
        if (itemDataSo == null) return;
        _renderer.sprite = itemDataSo.SpriteLibrary.GetSprite("idle_C1_down", "0");
        _spriteLibrary.spriteLibraryAsset = itemDataSo.SpriteLibrary;
    }

    public void SetAnimation(string nameHorizontal, string nameVertical, int horizontal, int vertical)
    {
        _animator.SetFloat(nameHorizontal, horizontal);
        _animator.SetFloat(nameVertical, vertical);
    }

    public void ClearData()
    {
        _renderer.enabled = false;
        _renderer.sprite = null;
        _spriteLibrary.spriteLibraryAsset = null;
    }

    public void SetAnimation(string name, bool value)
    {
        if (_renderer.enabled)
            _animator.SetBool(name, value);
    }
    public void SetAnimation(string name, float value)
    {
        if (_renderer.enabled)
            _animator.SetFloat(name, value);
    }
}

using UnityEngine;

public abstract class ObjectInteract : MonoBehaviour, IObjectInteract
{
    public virtual void Interact()
    {
        Destroy(gameObject);
    }

    public virtual bool IsHighlight => true;
}

public interface IObjectInteract
{
    void Interact();
    bool IsHighlight { get; }
}

using UnityEngine;

public abstract class ToolInteract : MonoBehaviour, IObjectInteract
{
    public virtual void Interact()
    {
        Destroy(gameObject);
    }
}

public interface IObjectInteract
{
    void Interact();
}

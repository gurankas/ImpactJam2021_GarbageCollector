using UnityEngine;

public interface IInteractable
{
    void Interact(Transform other);
    void StopInteraction();
}

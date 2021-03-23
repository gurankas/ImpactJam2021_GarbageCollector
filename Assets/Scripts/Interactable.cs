using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public void Interact(Transform other)
    {
        Debug.Log($"You're interacting with {other.name}");
    }

    public void StopInteraction()
    {

    }
}

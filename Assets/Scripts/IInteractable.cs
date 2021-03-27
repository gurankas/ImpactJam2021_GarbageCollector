using UnityEngine;

public interface IInteractable
{
    void Interact(Transform other, Interactable otherObject, GameObject origin);
    void StopInteraction();
    void ChangeSortingOrder(int sortingOrder);
}

using UnityEngine;

public interface IInteractable
{
    void Interact(Transform other, Interactable otherObject);
    void StopInteraction();
    void ChangeSortingOrder(int sortingOrder);
}

using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject _highlight;

    virtual public void Awake()
    {
        SetActiveHighlight(false);
    }

    virtual public void ChangeSortingOrder(int sortingOrder)
    {

    }

    virtual public void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
    }

    virtual public void StopInteraction()
    {

    }

    public void SetActiveHighlight(bool value)
    {
        _highlight.gameObject.SetActive(value);
    }

    public void SwitchHighlight(GameObject newHighlight)
    {
        _highlight = newHighlight;
    }
}

using UnityEngine;

public class Counter : Interactable
{
    [SerializeField]
    private Transform _itemPos;

    private Pickable _currentItem;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
        if (otherObject != null)
        {
            if (_currentItem == null)
            {
                _currentItem = otherObject.GetComponent<Pickable>();
                otherObject.transform.parent = _itemPos;
                otherObject.transform.localPosition = Vector3.zero;
                Debug.Log("counter interaction on");
            }
            else
            {
                otherObject.transform.parent = null;
                otherObject.transform.localScale = Vector3.one;
                _currentItem = null;
                Debug.Log("counter interaction off");
            }
        }
    }

    public override void StopInteraction()
    {
        //does not get called (not needed yet)
    }
}

using UnityEngine;

public class Sink : Interactable
{
    [SerializeField]
    private Transform _itemPos;

    private Pickable _currentItem;

    public float timeToComplete;

    private float _timeRemaining;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Interact(Transform other, Interactable otherObject)
    {
        if(otherObject is Pickable)
        {
            Pickable pickable = (Pickable)otherObject;
            if (pickable.extraSteps.Contains(Pickable.EXTRASTEPS.SINK))
            {
                if (_currentItem == null)
                {
                    //TODO integration of progress bar here
                    _currentItem = otherObject.GetComponent<Pickable>();
                    otherObject.transform.parent = _itemPos;
                    otherObject.transform.localPosition = Vector3.zero;
                    Debug.Log("Started washing");
                    pickable._canPickup = false;

                    _timeRemaining = timeToComplete;
                }
                else if (_timeRemaining <= 0)
                {

                    otherObject.transform.parent = null;
                    otherObject.transform.localScale = Vector3.one;
                    _currentItem = null;

                    pickable.extraSteps.Remove(Pickable.EXTRASTEPS.SINK);
                    Debug.Log("counter interaction off");
                }
                else
                {
                    Debug.Log("Not ready");

                }
            }
        }
    }

    private void Update()
    {
        if(_currentItem != null)
        {
            if(_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            } else
            {
                ((Pickable)_currentItem)._canPickup = true;
            }

        }
    }

    public override void StopInteraction()
    {

    }
}

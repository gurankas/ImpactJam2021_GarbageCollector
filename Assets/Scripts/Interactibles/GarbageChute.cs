using UnityEngine;

public class GarbageChute : Interactable
{
    [SerializeField]
    private bool _recycleable = false;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Interact(Transform other, Interactable otherObject)
    {
        if (otherObject != null)
        {
            var dumpItem = otherObject.GetComponent<Pickable>();
            if (dumpItem?.recycleable == _recycleable)
            {
                Debug.Log("That is the correct bin");
            }
            else
            {
                Debug.Log("Wrong bin");
            }
            dumpItem.SelfDestruct();
        }
    }

    public override void StopInteraction()
    {
        //doesnt really need to do anything at this point
    }
}

using UnityEngine;

public class Sink : Interactable
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Interact(Transform other, Interactable otherObject)
    {
        throw new System.NotImplementedException();
    }

    public override void StopInteraction()
    {
        throw new System.NotImplementedException();
    }
}

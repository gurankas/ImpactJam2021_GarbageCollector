using UnityEngine;

public class GarbageChute : Interactable
{
    [SerializeField]
    private bool _biodegradable;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Interact(Transform other)
    {
        throw new System.NotImplementedException();
    }

    public override void StopInteraction()
    {
        throw new System.NotImplementedException();
    }
}

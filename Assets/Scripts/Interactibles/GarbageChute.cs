using UnityEngine;

public class GarbageChute : Interactable
{
    [SerializeField]
    private TrashManager.TRASHCATS _category;

    [SerializeField]
    private GameManager gameManager;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Interact(Transform other, Interactable otherObject)
    {
        if (otherObject != null)
        {
            var dumpItem = otherObject.GetComponent<Pickable>();
            if (dumpItem.Grounded == true) return;

            if (dumpItem.trashCategory.Equals(_category))
            {
                Debug.Log("That is the correct bin");
                gameManager.score +=  TrashManager.getDetails(dumpItem.trashType).pointsPositive;
            }
            else
            {
                gameManager.score += TrashManager.getDetails(dumpItem.trashType).pointsNegative;
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

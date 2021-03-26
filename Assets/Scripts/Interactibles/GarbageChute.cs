using UnityEngine;

public class GarbageChute : Interactable
{
    public MotherNature motherNature;

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
            if(otherObject is Pickable)
            {

                var dumpItem = (Pickable)otherObject;
                if(dumpItem.extraSteps.Count == 0)
                {
                    if (dumpItem.Grounded == true) return;

                    motherNature.gameObject.SetActive(true);
                    if (dumpItem.trashCategory.Equals(_category))
                    {
                        Debug.Log("That is the correct bin");
                        gameManager.score += TrashManager.getDetails(dumpItem.trashType).pointsPositive;
                        motherNature.GivePositiveFeedback();
                    }
                    else 
                    {
                        gameManager.score += TrashManager.getDetails(dumpItem.trashType).pointsNegative;
                        Debug.Log("Wrong bin");

                        if (dumpItem.trashCategory.Equals(TrashManager.TRASHCATS.RECYCLABLE))
                        {
                            motherNature.GiveNegativeFeedbackOnTrash();
                        }
                        else
                        {
                            motherNature.GiveNegativeFeedbackOnRecycle();
                        }
                    }
                    dumpItem.SelfDestruct();
                }
            }
        }
    }

    public override void StopInteraction()
    {
        //doesnt really need to do anything at this point
    }
}

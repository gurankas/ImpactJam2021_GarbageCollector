using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GarbageChute : Interactable
{

    [SerializeField]
    private TrashManager.TRASHCATS _category;

    [SerializeField]
    private AudioClip _wrongSFX;

    [SerializeField]
    private AudioClip _correctSFX;

    [SerializeField]
    private AudioClip _errorSFX;

    private MotherNature _motherNature;
    private GameManager _gameManager;
    private AudioSource _as;

    public override void Awake()
    {
        base.Awake();
        _as = GetComponent<AudioSource>();
        _gameManager = FindObjectOfType<GameManager>();
        _motherNature = FindObjectOfType<MotherNature>();
        // print($"{_motherNature.gameObject.name}");
    }

    private void Start()
    {
        _motherNature.gameObject.SetActive(false);
    }

    public override void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
        if (otherObject != null)
        {
            if (otherObject is Pickable)
            {

                var dumpItem = (Pickable)otherObject;

                //correct
                if (dumpItem.extraSteps.Count == 0)
                {
                    if (dumpItem.Grounded == true) return;

                    _motherNature.gameObject.SetActive(true);
                    if (dumpItem.trashCategory.Equals(_category))
                    {
                        // Debug.Log("That is the correct bin");
                        _as.PlayOneShot(_correctSFX);
                        _gameManager.score += TrashManager.getDetails(dumpItem.trashType).pointsPositive;
                        _motherNature.GivePositiveFeedback();
                    }

                    //not correct recycling
                    else
                    {
                        _gameManager.score += TrashManager.getDetails(dumpItem.trashType).pointsNegative;
                        // Debug.Log("Wrong bin");

                        _as.PlayOneShot(_wrongSFX);
                        if (dumpItem.trashCategory.Equals(TrashManager.TRASHCATS.RECYCLABLE))
                        {
                            _motherNature.GiveNegativeFeedbackOnTrash();
                        }
                        else
                        {
                            _motherNature.GiveNegativeFeedbackOnRecycle();
                        }
                    }
                    dumpItem.SelfDestruct();
                }
                //some steps are pending so give incorrect disposal feedback
                else
                {
                    // Debug.Log("can't dispose off yet");
                    _as.PlayOneShot(_errorSFX);
                    _motherNature.gameObject.SetActive(true);
                    _motherNature.GiveIncorrectDisposalFeedback();
                }
            }
        }
    }

    public override void StopInteraction()
    {
        //doesnt really need to do anything at this point
    }
}

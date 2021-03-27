using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Compressor : Interactable
{
    [SerializeField]
    private Transform _itemPos;

    [SerializeField]
    private AudioClip _sinkSFX;

    private Pickable _currentItem;

    public float timeToComplete;

    private float _timeRemaining;
    private AudioSource _as;

    public GameObject canvas;
    public GameObject sliderPrefab;
    private GameObject _currentSlider;
    private Slider _currentSliderValue;

    public override void Awake()
    {
        _timeRemaining = timeToComplete;
        base.Awake();
        _as = GetComponent<AudioSource>();
    }

    public override void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
        if (otherObject is Pickable)
        {
            Pickable pickable = (Pickable)otherObject;
            if (pickable.extraSteps.Contains(Pickable.EXTRASTEPS.COMPRESSOR) && !pickable.extraSteps.Contains(Pickable.EXTRASTEPS.SINK))
            {
                if (_currentItem == null)
                {
                    _currentItem = otherObject.GetComponent<Pickable>();
                    otherObject.transform.parent = _itemPos;
                    otherObject.transform.localPosition = Vector3.zero;
                    // Debug.Log("Started washing");
                    _as.PlayOneShot(_sinkSFX);
                    pickable._canPickup = false;

                    _timeRemaining = timeToComplete;
                    Transform newTransform = transform;
                    _currentSlider = Instantiate(sliderPrefab, transform);
                    _currentSlider.transform.localPosition = new Vector3(0, 0, _currentSlider.transform.position.z);
                    _currentSlider.transform.GetChild(0).GetComponent<TaskProgress>().taskDuration = timeToComplete;

                }
            }
        }
    }


    private void Update()
    {
        if (_currentItem != null)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                ((Pickable)_currentItem)._canPickup = true;
                ((Pickable)_currentItem).extraSteps.Remove(Pickable.EXTRASTEPS.COMPRESSOR);
            }

        }
    }
}

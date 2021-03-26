using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Sink : Interactable
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
        base.Awake();
        _as = GetComponent<AudioSource>();
    }

    public override void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
        if (otherObject is Pickable)
        {
            Pickable pickable = (Pickable)otherObject;
            if (pickable.extraSteps.Contains(Pickable.EXTRASTEPS.SINK))
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

                    _currentSlider = Instantiate(sliderPrefab, canvas.transform);
                    _currentSliderValue = _currentSlider.GetComponent<Slider>();
                    _currentSliderValue.value = 1f;
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
        if (_currentItem != null)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                _currentSliderValue.value = _timeRemaining / timeToComplete;


                _currentSlider.transform.position = Camera.main.WorldToScreenPoint(new Vector3(_itemPos.transform.position.x, _itemPos.transform.position.y, _itemPos.transform.position.z));
                _currentSlider.transform.position = new Vector3(_currentSlider.transform.position.x - (_currentSlider.GetComponent<RectTransform>().rect.width / 3), _currentSlider.transform.position.y + 50, _currentSlider.transform.position.z);
            }
            else
            {
                Destroy(_currentSlider);
                _currentSliderValue = null;
                ((Pickable)_currentItem)._canPickup = true;
            }

        }
    }

    public override void StopInteraction()
    {

    }
}

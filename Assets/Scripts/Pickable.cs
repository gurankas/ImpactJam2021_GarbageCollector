using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject _highlight;

    private float _distance;

    private Player _player;

    private Rigidbody2D _rigidBody;

    private Transform _holder;

    private SpriteRenderer _sr;

    [SerializeField]
    private float _lerpSpeed = 8f;

    private void Awake()
    {
        SetActiveHighlight(false);
    }

    public void Interact(Transform attachTransform)
    {
        _holder = attachTransform;
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_holder == null) return;

        transform.position = Vector2.Lerp(transform.position, _holder.position, _lerpSpeed * Time.deltaTime);
    }

    public void StopInteraction()
    {
        _holder = null;
    }

    public void ChangeSortingOrder(int sortingOrder)
    {
        _sr.sortingOrder = sortingOrder;
    }

    public void SetActiveHighlight(bool value)
    {
        _highlight.gameObject.SetActive(value);
    }
}

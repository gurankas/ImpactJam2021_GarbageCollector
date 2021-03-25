using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    private Rigidbody2D _rigidBody;

    private Transform _holder;

    private SpriteRenderer _sr;

    [SerializeField]
    private float _lerpSpeed = 8f;

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
}

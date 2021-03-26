using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickable : Interactable
{
    private float _distance;

    private PlayerController _player;

    private Rigidbody2D _rigidBody;

    private Transform _holder;

    private SpriteRenderer _sr;

    [SerializeField]
    public bool recycleable = false;

    [HideInInspector]
    public bool Grounded = true;

    [SerializeField]
    private float _lerpSpeed = 8f;

    public override void Interact(Transform attachTransform, Interactable otherObject)
    {
        base.Interact(attachTransform, otherObject);
        _holder = attachTransform;
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_holder == null) return;

        transform.position = Vector2.Lerp(transform.position, _holder.position, _lerpSpeed * Time.deltaTime);
    }

    public override void StopInteraction()
    {
        Debug.Log("Dropped");
        base.StopInteraction();
        _holder = null;
    }

    public override void ChangeSortingOrder(int sortingOrder)
    {
        base.ChangeSortingOrder(sortingOrder);
        _sr.sortingOrder = sortingOrder;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}

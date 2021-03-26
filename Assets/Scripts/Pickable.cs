using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickable : Interactable
{
    public List<EXTRASTEPS> extraSteps = new List<EXTRASTEPS>();

    private float _distance;

    private PlayerController _player;

    private Rigidbody2D _rigidBody;

    private Transform _holder;

    private SpriteRenderer _sr;


    public TrashManager.TRASHTYPE trashType;
    [HideInInspector]
    public TrashManager.TRASHCATS trashCategory;

    [HideInInspector]
    public bool Grounded = true;

    [SerializeField]
    private float _lerpSpeed = 8f;

    [HideInInspector]
    public bool _canPickup = true;


    private void Start()
    {
        trashCategory = TrashManager.getCategory(trashType);
    }


    public override void Interact(Transform attachTransform, Interactable otherObject, GameObject origin)
    {
        if (_canPickup)
        {

            base.Interact(attachTransform, otherObject, null);
            _holder = attachTransform;
            _sr = GetComponent<SpriteRenderer>();
        }
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



    public enum EXTRASTEPS
    {
        SINK
    }
}

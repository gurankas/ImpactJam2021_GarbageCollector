using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickable : MonoBehaviour, IInteractable
{
    public Outline outline;

    private float _distance;

    private Player _player;

    private Rigidbody2D _rigidBody;

    private Transform _holder;

    private SpriteRenderer _sr;


    [SerializeField]
    private float _lerpSpeed = 8f;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 10;
        outline.enabled = false;
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

    private void FixedUpdate()
    {
        if (_player != null && _distance > 0.0f)
        {
            DisableOutlineWhenFar(_distance, _player);
        }
    }

    public void StopInteraction()
    {
        _holder = null;
    }

    public void ChangeSortingOrder(int sortingOrder)
    {
        _sr.sortingOrder = sortingOrder;
    }

    public void DisableOutlineWhenFar(float distance, Player player)
    {
        if (outline.enabled == true)
        {
            _player = player;
            _distance = distance;
            Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 currentPlayerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            if (Vector2.Distance(currentPos, currentPlayerPos) > distance)
            {
                outline.enabled = false;
            }
        }
    }
}

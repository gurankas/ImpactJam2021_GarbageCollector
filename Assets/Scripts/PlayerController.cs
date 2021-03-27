using UnityEngine;
using Rewired;


public class PlayerController : MonoBehaviour
{
    public int playerId = 0;
    private Player player;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private LayerMask _intaractableMask;

    [SerializeField]
    private LayerMask _pickupMask;

    public Transform _hand;

    [SerializeField]
    private GameObject _renderer;

    [SerializeField]
    private float _raycastLength;

    //current item for old iteraction system via overlap box
    private IInteractable _curInteractable;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector3 _boxOffset;
    private Vector3 _boxSize;
    private IsometricCharacterRenderer _isoRenderer;
    private Interactable _currentInteractItem;
    public Pickable _currentPickupItem;


    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);

        _animator = _renderer.GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    //All input handling should be in Update
    private void Update()
    {
        DetectPickups();
        DetectInteractibles();
        RaycastInteract();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void DetectPickups()
    {
        if (_currentPickupItem != null)
        {
            _currentPickupItem.SetActiveHighlight(false);
        }
        Vector2 direction = DetermineDirection(_isoRenderer.LastDirection);
        // Debug.DrawRay(_hand.position, direction * _raycastLength, Color.red, .5f);
        var hitResult = Physics2D.Raycast(_hand.position, direction, _raycastLength, _pickupMask);
        //Debug.Log($"{hitResult.collider.gameObject.name}");
        if (hitResult.collider?.gameObject != null)
        {
            _currentPickupItem = hitResult.collider.gameObject.GetComponent<Pickable>();
            _currentPickupItem.SetActiveHighlight(true);
        }

        else
        {
            _currentPickupItem = null;
        }
    }

    private void DetectInteractibles()
    {
        if (_currentInteractItem != null)
        {
            _currentInteractItem.SetActiveHighlight(false);
        }
        Vector2 direction = DetermineDirection(_isoRenderer.LastDirection);
        Debug.DrawRay(_hand.position, direction * _raycastLength, Color.red, .5f);
        var hitResult = Physics2D.Raycast(_hand.position, direction, _raycastLength, _intaractableMask);
        //Debug.Log($"{hitResult.collider.gameObject.name}");
        if (hitResult.collider?.gameObject != null)
        {
            _currentInteractItem = hitResult.collider.gameObject.GetComponent<Interactable>();
            _currentInteractItem.SetActiveHighlight(true);
        }
        else
        {
            _currentInteractItem = null;
        }
    }

    private void RaycastInteract()
    {
        if (player.GetButtonDown("Interact"))
        {
            //interaction based items
            if (_currentInteractItem != null)
            {
                _currentInteractItem.Interact(_hand, _currentPickupItem, gameObject);
                // Debug.Log($"Interacting with {_currentPickupItem.name}");
            }

            if (_currentPickupItem != null)
            {
                if (_currentPickupItem._canPickup)
                {

                    // Debug.Log($"item on the ground {_currentPickupItem.Grounded}");
                    //pickup item actions
                    if (_currentPickupItem.Grounded == true)
                    {
                        _currentPickupItem.Interact(_hand, null, gameObject);
                        // Debug.Log($"Picking up {_currentPickupItem.name}");
                        _currentPickupItem.Grounded = false;
                    }
                    else
                    {
                        _currentPickupItem.Grounded = true;
                        _currentPickupItem.StopInteraction();

                    }
                }
                else
                {
                    _currentPickupItem.Grounded = true;
                    _currentPickupItem.StopInteraction();

                }

            }
        }
    }

    private Vector2 DetermineDirection(int lastDirection)
    {
        switch (lastDirection)
        {
            case 0:
                {
                    return Vector2.up;
                }
            case 1:
                {
                    return Vector2.up + Vector2.left;
                }
            case 2:
                {
                    return Vector2.left;
                }
            case 3:
                {
                    return Vector2.left + Vector2.down;
                }
            case 4:
                {
                    return Vector2.down;
                }
            case 5:
                {
                    return Vector2.down + Vector2.right;
                }
            case 6:
                {
                    return Vector2.right;
                }
            case 7:
                {
                    return Vector2.right + Vector2.up;
                }
            default:
                return Vector2.up;
        }
    }

    private void OverlapBoxInteract()
    {
        //Action (interact)
        if (player.GetButtonDown("Interact"))
        {
            //Do Action here
            if (_curInteractable == null && _currentInteractItem != null)
            {
                var overlappingObjects = Physics2D.OverlapBoxAll(transform.position + transform.TransformVector(_boxOffset), _boxSize / 2f, 0, _intaractableMask);
                Debug.Log($"{overlappingObjects.Length}");
                if (overlappingObjects.Length <= 0) return;

                var obj = overlappingObjects[0];
                // Debug.Log($"{obj.transform.name}");
                _curInteractable = obj.GetComponent<IInteractable>();
                _curInteractable?.Interact(_hand, null, gameObject);
                _currentInteractItem.Interact(_hand, null, gameObject);
            }
            else
            {
                Debug.Log($"Interaction Stopped");
                _curInteractable.StopInteraction();
                _curInteractable = null;
            }
        }
    }

    private void Movement()
    {
        Vector2 currentPos = _rigidbody.position;
        float horizontalInput = player.GetAxis("Horizontal");
        float verticalInput = player.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * _speed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;

        _rigidbody.MovePosition(newPos);
        _isoRenderer.SetDirection(movement);


        _animator.SetFloat("moveX", inputVector.x);
        _animator.SetFloat("moveY", inputVector.y);
        _animator.SetFloat("speed", inputVector.sqrMagnitude);

        if (inputVector.x >= 0.5 || inputVector.x <= -0.5 || inputVector.y >= 0.5 || inputVector.y <= -0.5)
        {
            _animator.SetFloat("lastMoveX", inputVector.x);
            _animator.SetFloat("lastMoveY", inputVector.y);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position + transform.TransformVector(_boxOffset), _boxSize);
    }

}

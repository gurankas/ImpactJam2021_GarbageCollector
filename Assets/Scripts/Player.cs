using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Players _player;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private Vector3 _boxOffset;

    [SerializeField]
    private Vector3 _boxSize;

    [SerializeField]
    private LayerMask _intaractableMask;

    [SerializeField]
    private Transform _hand;

    [SerializeField]
    private GameObject _renderer;

    [SerializeField]
    private float _raycastLength;

    private IInteractable _curInteractable;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private KeyCode[] _keyCodes = new KeyCode[5];
    private IsometricCharacterRenderer _isoRenderer;
    private Interactable _currentItem;

    private void Awake()
    {
        _animator = _renderer.GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();

        if (_player == Players.Player1)
        {
            _keyCodes[0] = KeyCode.W;
            _keyCodes[1] = KeyCode.S;
            _keyCodes[2] = KeyCode.A;
            _keyCodes[3] = KeyCode.D;
            _keyCodes[4] = KeyCode.E;
        }
        else
        {
            _keyCodes[0] = KeyCode.UpArrow;
            _keyCodes[1] = KeyCode.DownArrow;
            _keyCodes[2] = KeyCode.LeftArrow;
            _keyCodes[3] = KeyCode.RightArrow;
            _keyCodes[4] = KeyCode.Return;
        }
    }

    //All input handling should be in Update
    private void Update()
    {
        Movement();
        //Interact();

        if (_currentItem != null)
        {
            _currentItem.SetActiveHighlight(false);
        }
        Vector2 direction = DetermineDirection(_isoRenderer.LastDirection);
        Debug.DrawRay(_hand.position, direction * _raycastLength, Color.red, .5f);
        var hitResult = Physics2D.Raycast(_hand.position, direction, _raycastLength, _intaractableMask);
        //Debug.Log($"{hitResult.collider.gameObject.name}");
        if (hitResult.collider?.gameObject != null)
        {
            _currentItem = hitResult.collider.gameObject.GetComponent<Interactable>();
            _currentItem.SetActiveHighlight(true);
        }
        else
        {
            _currentItem = null;
        }
        //TODO: enable and disable outline
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

    private void Interact()
    {
        //Action (interact)
        if (Input.GetKeyDown(_keyCodes[4]))
        {
            //Do Action here
            if (_curInteractable == null)
            {
                var overlappingObjects = Physics2D.OverlapBoxAll(transform.position + transform.TransformVector(_boxOffset), _boxSize / 2f, 0, _intaractableMask);
                Debug.Log($"{overlappingObjects.Length}");
                if (overlappingObjects.Length <= 0) return;

                var obj = overlappingObjects[0];
                // Debug.Log($"{obj.transform.name}");
                _curInteractable = obj.GetComponent<IInteractable>();
                _curInteractable?.Interact(_hand);
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
        //movement
        if (Input.GetKey(_keyCodes[0]) || Input.GetKey(_keyCodes[1]) || Input.GetKey(_keyCodes[2]) || Input.GetKey(_keyCodes[3]))
        {
            Vector2 currentPos = _rigidbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * _speed;
            Vector2 newPos = currentPos + movement * Time.deltaTime;
            _isoRenderer.SetDirection(movement);
            _rigidbody.MovePosition(newPos);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position + transform.TransformVector(_boxOffset), _boxSize);
    }

}

enum Players
{
    Player1,
    Player2
}

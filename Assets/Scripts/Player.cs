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

    private IInteractable _curInteractable;

    [SerializeField]
    private GameObject _renderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public Vector2 _movementVector;


    private KeyCode[] _keyCodes = new KeyCode[5];

    IsometricCharacterRenderer isoRenderer;

    private void Awake()
    {
        _animator = _renderer.GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();

        if (_player == Players.Player1)
        {
            _keyCodes[0] = KeyCode.W;
            _keyCodes[1] = KeyCode.S;
            _keyCodes[2] = KeyCode.A;
            _keyCodes[3] = KeyCode.D;
            _keyCodes[4] = KeyCode.E;
        } else
        {
            _keyCodes[0] = KeyCode.UpArrow;
            _keyCodes[1] = KeyCode.DownArrow;
            _keyCodes[2] = KeyCode.LeftArrow;
            _keyCodes[3] = KeyCode.RightArrow;
            _keyCodes[4] = KeyCode.Return;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(_keyCodes[0]) || Input.GetKey(_keyCodes[1]) || Input.GetKey(_keyCodes[2]) || Input.GetKey(_keyCodes[3]))
        {
            Vector2 currentPos = _rigidbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * _speed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            isoRenderer.SetDirection(movement);
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

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


    private void Awake()
    {
        _animator = _renderer.GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

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

    private void Update()
    {
        Vector2 _direction = Vector2.zero;

        

        if (Input.GetKey(_keyCodes[0]))
        {
            transform.Translate(Vector3.up.normalized * Time.deltaTime * _speed);
            _direction.y = 1;
        }
        if (Input.GetKey(_keyCodes[1]))
        {
            transform.Translate(Vector3.down.normalized * Time.deltaTime * _speed);
            _direction.y = -1;


        }
        if (Input.GetKey(_keyCodes[2]))
        {
            transform.Translate(Vector3.left.normalized * Time.deltaTime * _speed);
            _direction.x = -1;


        }
        if (Input.GetKey(_keyCodes[3]))
        {
            transform.Translate(Vector3.right.normalized * Time.deltaTime * _speed);
            _direction.x = 1;
        }


        _animator.SetFloat("xValue", _direction.x);
        _animator.SetFloat("yValue", _direction.y);
        _animator.SetFloat("velocity", _direction.sqrMagnitude);


        if (Input.GetKeyDown(_keyCodes[4]))
        {
            //Do Action here
            if (_curInteractable == null)
            {
                var overlappingObjects = Physics2D.OverlapBoxAll(transform.position + transform.TransformVector(_boxOffset), _boxSize / 2f, 0, _intaractableMask);
                if (overlappingObjects.Length <= 0) return;

                var obj = overlappingObjects[0];
                // Debug.Log($"{obj.transform.name}");
                _curInteractable = obj.GetComponent<IInteractable>();
                _curInteractable?.Interact(_hand);
            }
            else
            {
                _curInteractable.StopInteraction();
                _curInteractable = null;
            }
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

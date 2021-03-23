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

    private void Update()
    {
        //Player 1 controls
        if (_player == Players.Player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * _speed);
            }
            if (Input.GetKeyDown(KeyCode.E))
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

        //Player 2 controls
        if (_player == Players.Player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector2.down * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * Time.deltaTime * _speed);
            }
            if (Input.GetKeyDown(KeyCode.Return))
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

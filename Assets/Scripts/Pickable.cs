using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool _isG = false;

    private Rigidbody _rigidBody;

    private Transform _holder;

    [SerializeField]
    private float _lerpSpeed = 8f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Interact(Transform attachTransform)
    {
        _holder = attachTransform;
        _rigidBody.isKinematic = true;
    }

    private void Update()
    {
        if (_holder == null) return;

        transform.position = Vector3.Lerp(transform.position, _holder.position, _lerpSpeed * Time.deltaTime);
    }

    public void StopInteraction()
    {
        _holder = null;
        _rigidBody.isKinematic = false;
    }
}

using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 5;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}

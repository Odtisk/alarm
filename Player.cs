using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(Animator))]

public class Player : MonoBehaviour
{
    private float _lastPositionX;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private readonly int HasDanger = Animator.StringToHash(nameof(HasDanger));

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Alarm>(out var _))
        {
            _animator.SetBool(HasDanger, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Alarm>(out var _))
        {
            _animator.SetBool(HasDanger, false);
        }
    }

    private void FixedUpdate()
    {
        if (_lastPositionX != transform.position.x)
        {
            _spriteRenderer.flipX = _lastPositionX > transform.position.x;
        }

        _lastPositionX = transform.position.x;
    }
}

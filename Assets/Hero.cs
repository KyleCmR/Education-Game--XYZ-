using Newtonsoft.Json.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private LayerCheck _groundCheck;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isGrounded;
    private bool _allowDoubleJump;

    //private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
    //private static readonly int IsRunning = Animator.StringToHash("is-running");
    //private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");

    private int _coins;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private void Update()
    {
        _isGrounded = IsGrounded(); 
    }

    private void FixedUpdate()
    {
        var xVelocity = _direction.x * _speed;
        var yVelocity = CalculateYVelocity();
        _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

        _animator.SetBool("is-ground", _isGrounded);
        _animator.SetFloat("vertical-velocity", _rigidbody.velocity.y);
        _animator.SetBool("is-running", _direction.x != 0);
            
        UpdateSpriteDirection();
    }
    private float CalculateYVelocity()
    {
        var yVelocity = _rigidbody.velocity.y;
        var isJumpPressing = _direction.y > 0;

        if (_isGrounded) _allowDoubleJump = true;

        if (isJumpPressing)
        {
            yVelocity = CalculateJumpVelocity(yVelocity);
        }
        else if (_rigidbody.velocity.y > 0)
        {
            yVelocity *= 0.5f;
        }
        return yVelocity;
    }
    private float CalculateJumpVelocity(float yVelocity)
    {
        var isFalling = _rigidbody.velocity.y <= 0.001f;
        if (!isFalling) return yVelocity;
        if (_isGrounded)
        {
            yVelocity += _jumpSpeed;
        }
        else if (_allowDoubleJump)
        {
            yVelocity = _jumpSpeed;
            _allowDoubleJump = false;
        }
        return yVelocity;
    }
    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            _sprite.flipX = false;
        }                   
        else if (_direction.x < 0)
        {
            _sprite.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
    private bool IsGrounded()
    {
        return _groundCheck.IsTochingLayer;
    }

  
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private float _groundedRadius = 0.5f;

    private Rigidbody _rb;
    private Vector3 _moveDir;
    private bool _isGrounded;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
        GroundedCheck();
    }

    private void Move()
    {
        _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        var moveVectore = transform.TransformDirection(_moveDir) * _moveSpeed;
        _rb.velocity = new Vector3(moveVectore.x, _rb.velocity.y, moveVectore.z);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        }
    }

    private void GroundedCheck()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundedRadius, _groundLayers, QueryTriggerInteraction.Ignore);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(true);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}

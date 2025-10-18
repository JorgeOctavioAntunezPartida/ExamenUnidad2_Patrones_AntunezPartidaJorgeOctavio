using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionAsset InputAction;
    private InputAction moveAction;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Awake()
    {
        moveAction = InputAction.FindActionMap("Player").FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 verticalMove = new Vector2(0, moveInput.y);
        rb.MovePosition(rb.position + verticalMove * moveSpeed * Time.fixedDeltaTime);
    }
}
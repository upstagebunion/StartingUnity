using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int forwardForce = 1000;
    public int lateralForce = 800;
    private InputSystem_Actions playerControls;
    private Vector2 moveInput;

    void Awake()
    {
        playerControls = new InputSystem_Actions();
        playerControls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable()
    {
        playerControls.Player.Enable();
    }

    void OnDisable()
    {
        playerControls.Player.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        float horizontalForce = moveInput.x * lateralForce * Time.fixedDeltaTime;
        rb.AddForce(horizontalForce, 0, 0);
    }
}

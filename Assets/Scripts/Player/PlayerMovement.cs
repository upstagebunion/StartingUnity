using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int forwardForce;
    public int lateralForce;
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
        rb.AddForce(horizontalForce, 0, 0, ForceMode.VelocityChange);

        if (rb.position.y < -1f)
        {
            GameManager gameManager = (GameManager)FindAnyObjectByType(typeof(GameManager));
            gameManager.EndGame();
        }
    }
}

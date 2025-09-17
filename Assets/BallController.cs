using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movSpeed = 0f;
    public float launchForce = 0f;

    private Rigidbody rb;
    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private bool launched = false;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        controls = new InputSystem_Actions();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Attack.performed += ctx => LaunchBall();    

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
    private void Update()
    {
        if (!launched)
        {
            Vector3 move = new Vector3(moveInput.x, 0, 0) * movSpeed * Time.deltaTime;
        }
    }
    void LaunchBall()
    {
        launched = true;
        rb.AddForce(Vector3.forward * launchForce,ForceMode.Impulse);
    }
}

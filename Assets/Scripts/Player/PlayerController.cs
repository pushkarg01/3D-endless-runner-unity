using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClamp = 3f, zClamp = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovements();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement=context.ReadValue<Vector2>();
    }

    void HandleMovements()
    {
        Vector3 currentPos = rb.position;
        Vector3 moveDir = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPos = currentPos + moveDir * moveSpeed * Time.fixedDeltaTime;

        newPos.x =Mathf.Clamp(newPos.x,-xClamp,xClamp);
        newPos.z =Mathf.Clamp(newPos.z,-zClamp,zClamp);

        rb.MovePosition(newPos);
    }
}

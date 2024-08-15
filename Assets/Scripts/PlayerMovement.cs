using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] Joystick joystick;
    private Vector2 moveInput;
    [SerializeField] private uint circlecastRadius = 20;
    [SerializeField] private uint circlecastDistance = 30;
    [SerializeField] private LayerMask castingMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Walk();
        Look();
    }
    
    public void Walk()
    {
        moveInput = joystick.Direction;
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
    
    private void Look()
    {
        if (moveInput != Vector2.zero)
        {
            Rotate(moveInput);
        }
        else
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(
                transform.position, 
                circlecastRadius, 
                Vector2.up, 
                circlecastDistance, 
                castingMask);
            Vector2 closestEnemy = Vector2.positiveInfinity;
            foreach (var hit in hits)
            {
                closestEnemy = Vector2.Distance(hit.transform.position, transform.position) < 
                               Vector2.Distance(closestEnemy, transform.position) ? hit.transform.position : closestEnemy;
            }
            Vector2 direction = closestEnemy - (Vector2)transform.position;
            Rotate(direction);
        }
    }

    private void Rotate(Vector2 lookDirection)
    {
        float rotate = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotate - 90);
    }
}

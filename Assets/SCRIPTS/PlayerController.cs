using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float slowSpeed = 2f;  // kecepatan saat tahan Shift

    private Rigidbody2D rb;
    private Camera mainCamera;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleMovement();
        HandleFlashlightDirection();
    }

    void HandleMovement()
    {
        // Input dari WASD / Arrow Keys (8 arah otomatis)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(x, y).normalized;

        // Shift = gerak pelan
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? slowSpeed : moveSpeed;
        rb.linearVelocity = moveInput * currentSpeed;
    }

    void HandleFlashlightDirection()
    {
        // Ambil posisi mouse di dunia (bukan layar)
        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        // Hitung arah dari player ke mouse
        Vector2 direction = (mouseWorld - transform.position).normalized;
        
        // Rotasikan player / senter menghadap arah mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
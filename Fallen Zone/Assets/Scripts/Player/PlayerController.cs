using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public InventoryUI inventoryUI; // arrastrar desde el Inspector
    public Transform playerCamera;

    [Header("Movimiento")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float mouseSensitivity = 250f;
    public float jumpForce = 5f;

    [Header("Stamina")]
    public float maxStamina = 100f;
    public float stamina;
    public float staminaDrain = 20f;
    public float staminaRegen = 15f;

    [Header("Supervivencia")]
    public float maxHealth = 100f;
    public float health;

    public float maxHunger = 100f;
    public float hunger;
    public float hungerDrain = 1f;

    public float maxThirst = 100f;
    public float thirst;
    public float thirstDrain = 1.5f;

    public float healthDrainFromStarvation = 5f;

    Rigidbody rb;
    float xRotation;
    bool isGrounded;
    bool isRunning;

    public PlayerInventory inventory;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        stamina = maxStamina;
        health = maxHealth;
        hunger = maxHunger;
        thirst = maxThirst;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
        Jump();
        HandleStamina();
        HandleSurvivalStats();

        // TEST: subir inventario con la tecla I
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.inventory.inventoryLevel++;
            inventoryUI.inventory.ResizeInventory();
            inventoryUI.Refresh();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isRunning = Input.GetKey(KeyCode.LeftShift) && stamina > 0 && z > 0;

        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 direction = transform.forward * z + transform.right * x;

        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
    }

    void Look()
    {
        if (inventoryUI != null && inventoryUI.isInventoryOpen)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void HandleStamina()
    {
        stamina += (isRunning ? -staminaDrain : staminaRegen) * Time.deltaTime;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    void HandleSurvivalStats()
    {
        hunger -= hungerDrain * Time.deltaTime;
        thirst -= thirstDrain * Time.deltaTime;

        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        thirst = Mathf.Clamp(thirst, 0, maxThirst);

        if (hunger <= 0 || thirst <= 0)
        {
            health -= healthDrainFromStarvation * Time.deltaTime;
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float moveInput;

    [Header("Torch Pickup")]
    public GameObject currentTorch;                // Torch the player can interact with
    private bool hasTorch = false;

    [Header("Torch Hold Points")]
    public Transform torchHold_IdleRight;
    public Transform torchHold_RunRight;
    public Transform torchHold_IdleLeft;
    public Transform torchHold_RunLeft;

    private Transform activeTorchHoldPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement input
        moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = moveInput != 0;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("HasTorch", hasTorch);

        // Flip sprite based on direction
        if (isRunning)
        {
            spriteRenderer.flipX = moveInput > 0;
        }

        // Choose correct torch hold point
        if (hasTorch)
        {
            if (isRunning)
            {
                activeTorchHoldPoint = spriteRenderer.flipX ? torchHold_RunRight : torchHold_RunLeft;
            }
            else
            {
                activeTorchHoldPoint = spriteRenderer.flipX ? torchHold_IdleRight : torchHold_IdleLeft;
            }

            if (currentTorch != null && activeTorchHoldPoint != null)
            {
                currentTorch.transform.position = activeTorchHoldPoint.position;
                currentTorch.transform.rotation = activeTorchHoldPoint.rotation;
            }
        }

        // Pickup torch
        if (Input.GetKeyDown(KeyCode.E) && currentTorch != null && !hasTorch)
        {
            PickUpTorch();
        }

        // Drop torch
        if (Input.GetKeyDown(KeyCode.Q) && hasTorch)
        {
            DropTorch();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void PickUpTorch()
    {
        hasTorch = true;
        animator.SetTrigger("PickupTorch");

        // Determine initial hold point
        activeTorchHoldPoint = spriteRenderer.flipX
            ? (moveInput != 0 ? torchHold_RunRight : torchHold_IdleRight)
            : (moveInput != 0 ? torchHold_RunLeft : torchHold_IdleLeft);

        currentTorch.transform.SetParent(activeTorchHoldPoint);
        currentTorch.transform.localPosition = Vector3.zero;
        currentTorch.transform.localRotation = Quaternion.identity;

        Rigidbody2D torchRb = currentTorch.GetComponent<Rigidbody2D>();
        if (torchRb != null)
        {
            torchRb.simulated = false;
            torchRb.linearVelocity = Vector2.zero;
        }

        // Turn on torch light if present
        var light = currentTorch.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        if (light != null) light.enabled = true;
    }

    private void DropTorch()
    {
        if (currentTorch == null)
        {
            Debug.LogWarning("Tried to drop a torch, but none is assigned.");
            return;
        }

        hasTorch = false;
        animator.SetTrigger("DropTorch");

        currentTorch.transform.SetParent(null);

        Rigidbody2D torchRb = currentTorch.GetComponent<Rigidbody2D>();
        if (torchRb != null)
        {
            torchRb.simulated = true;
            torchRb.linearVelocity = Vector2.zero;
        }

        // Drop it in front of player
        Vector3 dropOffset = new Vector3(spriteRenderer.flipX ? -0.5f : 0.5f, 0, 0);
        currentTorch.transform.position = transform.position + dropOffset;

        currentTorch = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torch") && !hasTorch)
        {
            currentTorch = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Torch") && !hasTorch && other.gameObject == currentTorch)
        {
            currentTorch = null;
        }
    }
    public bool HasTorch()
    {
        return hasTorch;
    }

}

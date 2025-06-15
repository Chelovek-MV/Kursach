using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float attackRate = 0.5f;

    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private float nextAttackTime;
    private bool isLeft = false;

    private SpriteRenderer spriteRenderer;
    public static PlayerController Instance { get; private set; }

    void Start()
    {
        lookDirection = Vector2.right;
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeed += ClassSelectionManager.playerSpeedBonus;
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) moveY = 1f; // ¬верх
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) moveY = -1f; // ¬низ
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveX = -1f; // ¬лево
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveX = 1f; // ¬право

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveX < 0) { isLeft = true; }
        else if (moveX > 0) {
            isLeft = false; }

            if (isLeft) {
            spriteRenderer.flipX = true;
        }
        else { spriteRenderer.flipX = false; }


        if (moveDirection != Vector2.zero)
        {
            lookDirection = moveDirection;
        }

        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackRate;
        }
    }

    void FixedUpdate()
    {
        transform.parent.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        if (lookDirection == Vector2.zero)
        {
            lookDirection = transform.up;
        }

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(lookDirection);
        }
    }

    public Vector2 VectorRunning()
    {
        return moveDirection;
    }
}
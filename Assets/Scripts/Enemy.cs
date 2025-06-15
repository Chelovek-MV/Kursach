using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }

    public int maxHealth = 3;
    private int health = 0; // Здоровье врага
    public int damageToPlayer = 1; // Урон, наносимый игроку
    public float moveSpeed = 2f; // Базовая скорость движения
    public bool revers = false;
    private Transform player; // Ссылка на игрока
    private Rigidbody2D rb; // Rigidbody2D врага
    private SpriteRenderer spriteRenderer; // Компонент SpriteRenderer для зеркального отражения
    private bool canDamage = true; // Флаг для предотвращения спама урона
    private float damageCooldown = 1f; // Время между ударами
    private Animator animator;
    private CapsuleCollider2D collider;

    void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        // Подписываемся на событие увеличения скорости
        GameTimer.OnMinutePassed += IncreaseSpeed;
    }

    void Update()
    {
        if (player == null)
        {
            return; // Прекращаем выполнение метода, если игрок уничтожен
        }

        // Вычисляем направление к игроку
        Vector2 direction = (player.position - transform.position).normalized;

        // Зеркальное отражение спрайта
        if (!revers)
        {
            if (direction.x > 0 && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0 && !spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (direction.x > 0 && !spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x < 0 && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
        }

        // Двигаемся к игроку с помощью физики
        if (health > 0)
        {
            rb.linearVelocity = direction * moveSpeed;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamage)
        {
            // Наносим урон игроку
            //animator.SetTrigger("Attack");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);
                StartCoroutine(DamageCooldown());
            }
        }
    }

    System.Collections.IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        float healtRate = (float)health / maxHealth;
        Color color = Color.Lerp(Color.red, Color.white, healtRate);
        spriteRenderer.color = color;
    }

    void Die()
    {
        rb.linearVelocity = Vector2.zero;
        collider.enabled = false;
        animator.SetBool("Dead", true);
        KillCounter.Instance.AddKill();
        Destroy(gameObject, 0.6f);
    }

    void IncreaseSpeed()
    {
        moveSpeed += 0.2f; // Увеличиваем скорость врага
        Debug.Log($"Enemy speed increased to {moveSpeed}");
    }

    void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        GameTimer.OnMinutePassed -= IncreaseSpeed;
    }

    public void ClearPlayerReference()
    {
        player = null; // Обнуляем ссылку на игрока
    }
}
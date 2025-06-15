using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public GameTimer gameTimer;
    public Text healthText;
    private string playerHealth;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = maxHealth + ClassSelectionManager.playerHealthBonus;
        if (maxHealth == 0) { maxHealth = 1; }
        currentHealth = maxHealth;
        for (int i = 0;i < currentHealth; i++)
        {
            playerHealth += "♥️";
            if (i % 10 == 9) { playerHealth += "\n"; }
        }
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealth = null;
        for (int i = 0; i < currentHealth; i++)
        {
            playerHealth += "♥️";
            if (i % 10 == 9) { playerHealth += "\n"; }
        }
        Debug.Log($"Player Health: {currentHealth}");
        UpdateHealthText();
        if (currentHealth <= 0)
        {
            Die();
        }
        StartCoroutine(DamageEffect());
    }

    void Die()
    {
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
            float survivalTime = gameTimer.GetElapsedTime();
            Debug.Log($"Player survived for: {survivalTime:F2} seconds");
            DeathScreenManager.Instance.ShowDeathScreen(survivalTime);
        }
        RemoveAllEnemies();
        Destroy(gameObject);
    }
    void RemoveAllEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.ClearPlayerReference();
            Destroy(enemy.gameObject); 
        }
        Debug.Log("All enemies removed.");
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"\n{playerHealth}";
        }
    }

    IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
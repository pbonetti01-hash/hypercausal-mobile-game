using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("UI")]
    public Slider healthSlider;

    [Header("Ajustes de Gameplay")]
    [Tooltip("Quanto de dano o projetil comum causa")]
    public float danoPorAcerto = 0.1f;
    [Tooltip("Quanto de vida o item de life recupera")]
    public float curaPorItem = 0.15f;

    [Header("Configurações de Vida")]
    public float health = 1.0f;

    [Header("Sons e Música")]
    public AudioSource[] sonsParaParar;

    private bool isDead = false;

    void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.minValue = 0;
            healthSlider.maxValue = 1;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        health -= danoPorAcerto;
        health = Mathf.Clamp(health, 0, 1);

        if (healthSlider != null)
            healthSlider.value = health;

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;

        health += curaPorItem;
        health = Mathf.Clamp(health, 0, 1);

        if (healthSlider != null)
            healthSlider.value = health;
    }

    void GameOver()
    {
        isDead = true;
        Debug.Log("Game Over!");

        Time.timeScale = 0;

        foreach (AudioSource som in sonsParaParar)
        {
            if (som != null)
            {
                som.Stop();
            }
        }
    }
}
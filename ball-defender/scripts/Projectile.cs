using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configurações do Projétil")]
    [Tooltip("Se marcado, o projétil cura e mantém velocidade constante. Se desmarcado, causa dano e acelera.")]
    public bool isHeal = false;

    [Range(1f, 50f)]
    public float baseSpeed = 10f;

    [Header("Aceleração (Apenas para Tiros)")]
    [SerializeField] private float accelerationRate = 2f;

    private float currentSpeed;
    private Vector3 direction;

    public void Setup(Vector3 targetDirection, float projectileSpeed)
    {
        this.direction = targetDirection.normalized;
        this.currentSpeed = projectileSpeed > 0 ? projectileSpeed : baseSpeed;

        transform.forward = direction;

        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (!isHeal)
        {
            currentSpeed += accelerationRate * Time.deltaTime;
        }

        transform.position += direction * currentSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                if (isHeal)
                {
                    playerHealth.Heal(0.1f);
                }
                else
                {
                    playerHealth.TakeDamage(0.1f);
                }
            }

            Destroy(gameObject);
        }
    }
}
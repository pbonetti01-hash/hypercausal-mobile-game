using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [Header("Referências de Objetos")]
    public GameObject[] projectilePrefabs;
    public Transform playerTransform;

    [Header("Sons")]
    public AudioSource audioSource;
    public AudioClip somProjetilComum; 
    public AudioClip somItemVida;     

    [Header("Pontos de Spawn")]
    public Transform[] spawnPoints;

    [Header("Configurações de Dificuldade")]
    public float tempoParaDificuldadeMaxima = 120f;
    private float tempoDecorrido = 0f;

    [Header("Chances de Spawn (0 a 100)")]
    [Range(0, 100)] public float chanceDeLife = 20f;

    [Header("Limites de Fire Rate")]
    public float fireRateInicial = 3f;
    public float fireRateMinimo = 0.5f;

    [Header("Limites de Velocidade")]
    public float velocidadeInicial = 10f;
    public float velocidadeMaxima = 30f;

    private float nextFireTime;
    private float currentFireRate;
    private float currentProjectileSpeed;

    void Start()
    {
        currentFireRate = fireRateInicial;
        currentProjectileSpeed = velocidadeInicial;

        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerTransform == null || spawnPoints.Length == 0 || projectilePrefabs.Length < 2) return;

        AtualizarDificuldade();

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + currentFireRate;
        }
    }

    void AtualizarDificuldade()
    {
        tempoDecorrido += Time.deltaTime;
        float t = Mathf.Clamp01(tempoDecorrido / tempoParaDificuldadeMaxima);

        currentFireRate = Mathf.Lerp(fireRateInicial, fireRateMinimo, t);
        currentProjectileSpeed = Mathf.Lerp(velocidadeInicial, velocidadeMaxima, t);
    }

    void Shoot()
    {
        Transform selectedPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject selectedPrefab;
        AudioClip somParaTocar; 

        float sorteio = Random.Range(0f, 100f);

        if (sorteio <= chanceDeLife)
        {
            selectedPrefab = projectilePrefabs[1];
            somParaTocar = somItemVida; 
        }
        else
        {
            selectedPrefab = projectilePrefabs[0];
            somParaTocar = somProjetilComum; 
        }

        if (audioSource != null && somParaTocar != null)
        {
            audioSource.PlayOneShot(somParaTocar);
        }

        GameObject bullet = Instantiate(selectedPrefab, selectedPoint.position, Quaternion.identity);
        Vector3 shootDirection = playerTransform.position - selectedPoint.position;

        Projectile script = bullet.GetComponent<Projectile>();
        if (script != null)
        {
            script.Setup(shootDirection, currentProjectileSpeed);
        }
    }
}
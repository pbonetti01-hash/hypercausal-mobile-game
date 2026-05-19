using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Configurações de Upgrade")]
    public GameObject upgradeObject; 
    public float tempoParaUpgrade = 60f;
    
    private float cronometro = 0f;
    private bool upgradeAtivado = false;

    void Update()
    {
        
        if (!upgradeAtivado)
        {
            cronometro += Time.deltaTime;

            if (cronometro >= tempoParaUpgrade)
            {
                AtivarUpgrade();
            }
        }
    }

    void AtivarUpgrade()
    {
        upgradeAtivado = true;
        
        if (upgradeObject != null)
        {
            upgradeObject.SetActive(true); 
        }
    }
}
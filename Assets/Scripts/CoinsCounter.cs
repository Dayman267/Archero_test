using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    private int coinsCount;
    private TextMeshProUGUI coinsText;

    private void Awake()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
        coinsText.text = "Coins: 0";
    }

    private void ChangeCoins(int coins)
    {
        coinsCount += coins;
        coinsText.text = $"Coins: {coinsCount}";
    }
    
    private void OnEnable()
    {
        EnemyHealth.onEnemyDeath += ChangeCoins;
    }
    
    private void OnDisable()
    {
        EnemyHealth.onEnemyDeath -= ChangeCoins;
    }
}

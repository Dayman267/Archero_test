using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    private GameObject[] enemies;
    private SpriteRenderer battlefield;
    private GameObject parent;
    
    private string enemiesPrefabFolderPath = "Prefabs/Enemies";

    public static Action onGenerationEnded;
    public static Action<uint> onEnemiesSpawned;

    private void Start()
    {
        enemies = Resources.LoadAll<GameObject>(enemiesPrefabFolderPath);
        battlefield = GameObject.FindWithTag("Battlefield").GetComponent<SpriteRenderer>();
        parent = GameObject.FindWithTag("Enemies");
        SpawnEnemies();
        onGenerationEnded?.Invoke();
    }

    private void SpawnEnemies()
    {
        float limitX = battlefield.size.x / 2;
        
        float centerY = battlefield.size.y / 6 * 2;
        float limitY = centerY + battlefield.size.y / 6;
        float limitMinusY = centerY - battlefield.size.y / 6;
        
        uint enemiesCount = (uint)Random.Range(enemies.Length - 1, enemies.Length + 1);
        for (int i = 0; i < enemiesCount; i++)
        {
            var randomPositionX = Random.Range(-limitX, limitX);
            var randomPositionY = Random.Range(limitMinusY, limitY);
            var position = new Vector3(randomPositionX, randomPositionY, 10f);

            Instantiate(
                enemies[Random.Range(0, enemies.Length)],
                position, 
                Quaternion.identity, 
                parent.transform);
        }
        
        onEnemiesSpawned?.Invoke(enemiesCount);
    }
}

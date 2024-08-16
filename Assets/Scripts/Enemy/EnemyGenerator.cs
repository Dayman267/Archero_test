using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject battlefield;
    private GameObject parent;
    
    private string enemiesPrefabFolderPath = "Prefabs/Enemies";

    public static Action onGenerationEnded;
    public static Action<uint> onEnemiesSpawned;

    private void Start()
    {
        enemies = Resources.LoadAll<GameObject>(enemiesPrefabFolderPath);
        battlefield = GameObject.FindWithTag("Battlefield");
        parent = GameObject.FindWithTag("Enemies");
        SpawnEnemies();
        onGenerationEnded?.Invoke();
    }

    private void SpawnEnemies()
    {
        float limitX = battlefield.transform.localScale.x / 2;
        
        float centerY = battlefield.transform.localScale.y / 6 * 2;
        float limitY = centerY + battlefield.transform.localScale.y / 6;
        float limitMinusY = centerY - battlefield.transform.localScale.y / 6;
        
        uint enemiesCount = (uint)Random.Range(enemies.Length, enemies.Length + 2);
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
        Debug.Log(enemiesCount);
    }
}

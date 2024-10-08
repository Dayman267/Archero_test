using UnityEngine;

public class DoorController : MonoBehaviour
{
    private uint enemiesCount;
    [SerializeField] private GameObject finalDoors;
    [SerializeField] private GameObject teleport;

    private void FixedUpdate()
    {
        if (enemiesCount <= 0)
        {
            finalDoors.SetActive(true);
            teleport.SetActive(true);
        }
    }

    private void OnEnable()
    {
        EnemyGenerator.onEnemiesSpawned += count => enemiesCount = count;
        EnemyHealth.onEnemyDeath += _ => enemiesCount -= 1;
    }

    private void OnDisable()
    {
        EnemyGenerator.onEnemiesSpawned -= count => enemiesCount = count;
        EnemyHealth.onEnemyDeath -= _ => enemiesCount -= 1;
    }
}
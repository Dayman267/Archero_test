using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int bulletsCount = 7;
    [SerializeField] private float maxDeflection = 0.3f;

    protected override void Shoot()
    {
        for (int i = 0; i <= bulletsCount; i++)
        {
            GameObject bulletGo = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector2 randomDirection = new Vector2(
                playerMovement.DirectionToClosestEnemy().x + Random.Range(-maxDeflection, maxDeflection), 
                playerMovement.DirectionToClosestEnemy().y + Random.Range(-maxDeflection, maxDeflection));
            bulletGo.GetComponent<Bullet>().Init(playerRB.gameObject, damage, speed, randomDirection);
        }
    }
}

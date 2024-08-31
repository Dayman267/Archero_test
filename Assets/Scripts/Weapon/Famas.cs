using System.Collections;
using UnityEngine;

public class Famas : Weapon
{
    [SerializeField] private float secBetweenBullets = 0.1f;

    protected override void Shoot()
    {
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bulletGo = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletGo.GetComponent<Bullet>().Init(
                playerRB.gameObject, 
                damage, 
                speed, 
                playerMovement.DirectionToClosestEnemy());
            yield return new WaitForSeconds(secBetweenBullets);
        }
    }
}

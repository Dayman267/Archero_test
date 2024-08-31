using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private float bulletSpeed = 8f;

    protected override void Shoot()
    {
        GameObject bulletGo = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletGo.GetComponent<Bullet>().Init(
            playerRB.gameObject, 
            damage, 
            bulletSpeed, 
            playerMovement.DirectionToClosestEnemy());
    }
}

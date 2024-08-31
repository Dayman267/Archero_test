using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Rigidbody2D playerRB;
    protected PlayerMovement playerMovement;
    protected GameObject bullet;
    protected Joystick joystick;

    protected float secLeft;
    [SerializeField] protected float secBetweenShots;
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;

    protected bool canContinue;

    protected virtual void Start()
    {
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        playerMovement = playerRB.gameObject.GetComponent<PlayerMovement>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullets/Bullet");
        joystick = FindObjectOfType<Joystick>();
    }

    private void FixedUpdate()
    {
        if (!canContinue) return;
        if (secLeft <= 0)
        {
            if (joystick.Direction.magnitude == 0)
            {
                Shoot();
                secLeft = secBetweenShots;
            }
        }
        else secLeft -= Time.deltaTime;
    }

    protected abstract void Shoot();

    private void CheckEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 1) return;
        canContinue = false;
    }

    private void OnEnable()
    {
        Timer.onTimerEnded += () => canContinue = true;
        EnemyHealth.onEnemyDeath += _ => CheckEnemies();
    }

    private void OnDisable()
    {
        Timer.onTimerEnded -= () => canContinue = true;
        EnemyHealth.onEnemyDeath -= _ => CheckEnemies();
    }
}

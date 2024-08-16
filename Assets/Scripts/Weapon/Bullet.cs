using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
    private float damage;
    private float speed;
    Vector2 direction;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(GameObject _parent, float _damage, float _speed, Vector2 _direction)
    {
        parent = _parent;
        damage = _damage;
        speed = _speed;
        direction = _direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag(parent.tag)) return;
        if(collider.gameObject.CompareTag("Enemy")) 
            collider.gameObject.GetComponent<EnemyHealth>().GetDamage(damage);
        else if(collider.gameObject.CompareTag("Player")) 
            collider.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
        else if(collider.gameObject.CompareTag("AttachedToPlayer") ||
                collider.gameObject.CompareTag("Bullet")) return;
        Destroy(gameObject);
    }
}

using UnityEngine;

public class freezeBolt : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifeTime = 5f;
    Rigidbody2D rb;

    private PlayerMovement _playerMovement;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Start()
    {
        if (_playerMovement.direction == 1)
        {
            rb.linearVelocity = transform.right * speed;
            Debug.Log("Shoot Right");
        }
        else 
        {
            rb.linearVelocity = (transform.right * -1) * speed;
            Debug.Log("Shoot Left");
        }
        
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        enemyAI enemy = other.GetComponent<enemyAI>();

        if( enemy != null){
            enemy.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }
}

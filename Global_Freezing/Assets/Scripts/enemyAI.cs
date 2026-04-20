using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class enemyAI : MonoBehaviour, IDamageable
{
    [Header("stats")]
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float damageAmount = 10f;

    [SerializeField] private float attackRange = 1f;
    private Animator animator;
    public GameObject frozenEnemy;

    public bool isFrozen = false;

    [Header("Patrol Bounds")]
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;

    private float currentHealth;
    private float attackTimer = 0f;
    private Transform player;
    private bool isMovingRight = true;
    private Rigidbody2D rb;

    void Awake(){
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if(playerHealth != null){
            player = playerHealth.transform;
            }
    }
    void Update(){
        if(currentHealth <= 0) return;
        attackTimer -= Time.deltaTime;
        if(player != null){
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRange){
                ChasePlayer(distanceToPlayer);
            }
            else{
                Patrol();
            }
        }
        else{
            Patrol();
        }
        if(animator != null){
            animator.SetBool("isFrozen", isFrozen);
        }
    }
    private void ChasePlayer(float distanceToPlayer){
        if(distanceToPlayer <= attackRange){
            IDamageable playerDamageable = player.GetComponent<IDamageable>();
            if(playerDamageable != null && attackTimer <= 0f){
                playerDamageable.ApplyDamage(damageAmount);
                attackTimer = attackCooldown;
            }
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        else{
            float direction = player.position.x > transform.position.x ? 1f: -1f;
            Move(direction);
        }
    }
    private void Patrol(){
        if(leftBound != null && rightBound != null){
            if(isMovingRight && transform.position.x >= rightBound.position.x)
            isMovingRight = false;
            else if(!isMovingRight && transform.position.x <= leftBound.position.x)
            isMovingRight = true;
        }
        Move(isMovingRight ? 1f: -1f);
    }
    private void Move(float direction){
        if(rb != null){
            rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        }
        if(direction != 0){
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x)*(direction > 0 ? 1 : -1);
        }
    }
    public bool ApplyDamage(float damage){
        if(currentHealth <= 0f) return false;
        currentHealth -= damage;
        if(currentHealth <= 0f){
            Die();
            return true;
        }
        return true;
    }
    private void Die(){
        Instantiate(frozenEnemy, transform.position, transform.rotation);
        Destroy(gameObject);
        rb.linearVelocity = Vector2.zero;
      
        isFrozen = true;
        //gameObject.SetActive(false);
    }
}


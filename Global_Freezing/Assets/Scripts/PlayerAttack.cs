using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform icepoint;
    [SerializeField] private GameObject[] icebolts;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake(){
        animator = GetComponent<Animator>();
        //playerMovement = GetComponent<playerMovement>();
    }
    private void Update(){
        if(Input.GetMouseButton(0) && cooldownTimer >attackCooldown){
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack(){
        animator.SetTrigger("attack");
        cooldownTimer = 0;

        icebolts[FindIcebolt()].transform.position = icepoint.position;
        icebolts[FindIcebolt()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindIcebolt(){
        for(int i = 0; i < icebolts.Length; i++){
            if(!icebolts[i].activeInHierarchy)
            return i;
        }
        return 0;
    }
}

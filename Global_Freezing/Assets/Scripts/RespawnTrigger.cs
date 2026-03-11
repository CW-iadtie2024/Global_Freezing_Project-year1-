using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 playerRespawnPosition = new Vector3(0,2,0);
    [SerializeField] private Vector3 enemyRespawnPosition = new Vector3(-2,2,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            var player = collision.GetComponent<PlayerHealth>();
            if(player!=null){
                collision.transform.position = playerRespawnPosition;
            }
        }
        else if(collision.CompareTag("Enemy")){
            var enemy = collision.GetComponent<enemyAI>();
            if(enemy!=null){
                collision.transform.position = enemyRespawnPosition;
            }
        }
        
    }
}
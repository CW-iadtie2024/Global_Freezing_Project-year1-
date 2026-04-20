using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform icepointRight;
    public Transform icepointLeft;
    public GameObject icebolt;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float fireRate = 3f;
    float timer;

    void Awake()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update(){
        timer += Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && timer >= fireRate && playerMovement.direction == 1)
        {
            Shoot("Right");
            timer = 0f;
        }
        else if (Input.GetButtonDown("Fire1") && timer >= fireRate && playerMovement.direction == -1)
        {
            Shoot("Left");
            timer = 0f;
        }
    }
    public void Shoot(string direction)
    {
        if(direction == "Left")
        {
            Instantiate(icebolt, icepointLeft.position, icepointLeft.rotation);
            Debug.Log("bullet left");
        }
        else if (direction == "Right")
        {
            Instantiate(icebolt, icepointRight.position, icepointRight.rotation);
            Debug.Log("bullet right");
        }
        
    }

    // public void Shoot()
    // {
    //     Instantiate(icebolt, icepoint.position, icepoint.rotation);
    //     Debug.Log("bullet");
    // }
}

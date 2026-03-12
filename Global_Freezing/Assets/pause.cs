using UnityEngine;

public class pause : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetButton("Crouch") && Time.timeScale == 1){
            Time.timeScale = 0;
        }
        else if (Input.GetButton("Crouch") && Time.timeScale == 0){
            Time.timeScale = 1;
        }
    }
}

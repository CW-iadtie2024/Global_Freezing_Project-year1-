using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{
        get;private set;
    }
    public int CollectibleCount = 0;
    public TMP_Text collectibleText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        collectibleText.text =$"Collectibles: {CollectibleCount}";
    }
    public void AddCollectible(){
        CollectibleCount++;
        UpdateCollectibleUI();
    }

    private void UpdateCollectibleUI(){
        if(collectibleText != null){
            collectibleText.text=$"Collectibles: {CollectibleCount}";
        }
    }
}   

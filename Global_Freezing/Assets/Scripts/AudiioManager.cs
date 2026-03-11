using UnityEngine;

public class AudiioManager : MonoBehaviour
{
    public static AudiioManager Instance {get;private set;}
    [Header("AudioSources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    [Header("AudioClips")]
    public AudioClip backgroundMusic;
    public AudioClip collectibleSFX;
    public AudioClip jumpSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Start(){
        if(backgroundMusic != null && musicSource != null){
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip){
        if(clip!=null && sfxSource != null){
            sfxSource.PlayOneShot(clip);
        }
    }

    // Update is called once per frame
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
}

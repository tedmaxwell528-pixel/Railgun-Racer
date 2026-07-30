using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource death = GetComponent<AudioSource>();
        death.clip = deathSound;
        death.Play();
    }

    public void Restart(){
        SceneLoader.MainMenu();
    }
}

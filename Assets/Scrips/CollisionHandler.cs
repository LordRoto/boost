using UnityEngine;
using UnityEngine.SceneManagement;




public class CollisionHandler : MonoBehaviour
{
        [SerializeField] float levelLoadDelay = 2f;
        [SerializeField] AudioClip splat;
        [SerializeField] AudioClip victory;

        [SerializeField] ParticleSystem splatParticles;
        [SerializeField] ParticleSystem victoryParticles;

        AudioSource audioSource;
       

        bool isTransitioning = false;

void Start()
    {

        audioSource = GetComponent <AudioSource>();


    }



     void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning){return;}



        switch (other.gameObject.tag) 
        {
            case "Friendly":
            Debug.Log ("Goo outta 'ere");
            break;
            case "Finish":
            Debug.Log ("ConGOOrats!");
            StartSuccessSequence();
            break;
            default:
            StartCrashSequence();
            break;
        }
        
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        audioSource.PlayOneShot(victory);
        victoryParticles.Play();

    }



    void StartCrashSequence()
    {
        
        
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        audioSource.PlayOneShot(splat);
        splatParticles.Play();

    }



  void LoadNextLevel ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }


    void ReloadLevel ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }



}

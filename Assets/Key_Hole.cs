using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public AudioClip soundEffect;         // Assign your SFX in the Inspector
    public GameObject objectToSpawn;      // Assign the prefab to spawn
    public Transform spawnLocation;       // Where to spawn the object
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key")) // or another tag you're looking for
        {
            audioSource.PlayOneShot(soundEffect);

            if (objectToSpawn != null && spawnLocation != null)
            {
                Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
            }
        }
    }
}

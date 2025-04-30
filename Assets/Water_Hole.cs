using UnityEngine;

public class TriggerResponse : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    public GameObject objectToSpin;  // This must be a scene object (not a prefab)
    public float spinSpeed = 100f;

    public Light targetLight;
    public float targetIntensity = 5f;
    public float lightChangeSpeed = 2f;

    private bool shouldSpin = false;
    private bool lightTriggered = false;

    void Update()
    {
        if (shouldSpin && objectToSpin != null)
        {
            objectToSpin.transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime, Space.Self);
        }

        if (lightTriggered && targetLight != null)
        {
            targetLight.intensity = Mathf.MoveTowards(targetLight.intensity, targetIntensity, lightChangeSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))  // Make sure your player is tagged correctly
        {
            // Spawn a new object
            if (objectToSpawn != null && spawnPoint != null)
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Start spinning the existing object
            shouldSpin = true;

            // Start increasing the light
            lightTriggered = true;
        }
    }
}

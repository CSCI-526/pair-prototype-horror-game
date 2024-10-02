using UnityEngine;

public class GhostAudioController : MonoBehaviour
{
    public float range1 = 15f;  // Radius for first range
    public float range2 = 10f; // Radius for second range
    public float range3 = 5f; // Radius for third range

    private AudioSource audioSourceRange1;
    private AudioSource audioSourceRange2;
    private AudioSource audioSourceRange3;

    private Transform targetGhost;

    void Start()
    {
        // Get all AudioSource components on this GameObject
        AudioSource[] audioSources = GetComponents<AudioSource>();
        
        if (audioSources.Length >= 3)
        {
            audioSourceRange1 = audioSources[0];
            audioSourceRange2 = audioSources[1];
            audioSourceRange3 = audioSources[2];
        }
        else
        {
            Debug.LogError("Not enough AudioSources attached to this GameObject. You need at least 3.");
        }
    }

    void Update()
    {
        // Find the closest "Ghost" object
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        targetGhost = FindClosestGhost(ghosts);

        if (targetGhost != null)
        {
            float distance = Vector3.Distance(transform.position, targetGhost.position);
            PlayAudioForRange(distance);
        }
        else
        {
            StopAllAudios();
        }
    }

    Transform FindClosestGhost(GameObject[] ghosts)
    {
        Transform closestGhost = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject ghost in ghosts)
        {
            float distance = Vector3.Distance(transform.position, ghost.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestGhost = ghost.transform;
            }
        }

        return closestGhost;
    }

    void PlayAudioForRange(float distance)
    {
        // Determine which range the ghost is in and play the corresponding audio
        if (distance <= range1 && distance > range2)
        {
            if (!audioSourceRange1.isPlaying)
            {
                StopAllAudios();
                Debug.Log("Playing audio for range 1");
                audioSourceRange1.Play();
            }
        }
        else if (distance <= range2 && distance > range3)
        {
            if (!audioSourceRange2.isPlaying)
            {
                StopAllAudios();
                Debug.Log("Playing audio for range 2");
                audioSourceRange2.Play();
            }
        }
        else if (distance <= range3)
        {
            if (!audioSourceRange3.isPlaying)
            {
                StopAllAudios();
                Debug.Log("Playing audio for range 3");
                audioSourceRange3.Play();
            }
        }
        else
        {
            // Stop all audios if the ghost is out of all ranges
            StopAllAudios();
            Debug.Log("No ghosts in range");
        }
    }

    void StopAllAudios()
    {
        // Stop all audio sources
        if (audioSourceRange1.isPlaying) audioSourceRange1.Stop();
        if (audioSourceRange2.isPlaying) audioSourceRange2.Stop();
        if (audioSourceRange3.isPlaying) audioSourceRange3.Stop();
    }
}
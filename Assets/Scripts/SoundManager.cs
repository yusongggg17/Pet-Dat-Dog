using System.Collections;
using System.Xml.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]public AudioSource audioSource;
    public AudioClip[] nameClips;
    public double soundDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playName(int index)
    {
        Debug.Log("Playing name clip at index: " + index);  
        if (index >= 0&& index<nameClips.Length && nameClips[index] != null) {
            StartCoroutine(PlayDelayed(nameClips[index], (float)soundDelay));
        }
        
    }

    IEnumerator PlayDelayed(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip, 1f);
    }
}

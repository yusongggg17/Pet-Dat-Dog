using System.Collections;
using System.Xml.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]public AudioSource audioSource;
    public AudioClip[] nameClips;
    public AudioClip explosion;
    public AudioClip explosionAlt;
    public AudioClip pipe;
    public AudioClip kick;
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
        if(index==50)audioSource.PlayOneShot(explosionAlt, 1f);
        else    audioSource.PlayOneShot(explosion, 0.5f);
        Debug.Log("Playing name clip at index: " + index);  
        if (index >= 0&& index<nameClips.Length && nameClips[index] != null) {
            StartCoroutine(PlayDelayed(nameClips[index], (float)soundDelay));
        }
        
    }
    public void playPipe()
    {
        audioSource.PlayOneShot(pipe, 0.1f);
    }
    public void playKick()
    {
        audioSource.PlayOneShot(kick, 1f);
    }
    IEnumerator PlayDelayed(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip, 0.8f);
    }
}

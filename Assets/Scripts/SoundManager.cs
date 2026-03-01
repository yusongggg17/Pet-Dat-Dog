using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]public AudioSource audioSource;
    //public AudioClip name1;
    [SerializeField]public AudioClip name1;
    public AudioClip name2;
    public AudioClip name3;
    public double soundDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundDelay=3.0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playName(int index){
        //source.AudioClip=name1;
        //audioSource.PlayOneShot(name1, 0.5f);
    }
}

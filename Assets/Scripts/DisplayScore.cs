using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Dogs exploded: " + savedScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

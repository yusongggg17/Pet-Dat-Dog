using UnityEngine;
using System.Collections;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class NextSCene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(next());
    }
    IEnumerator next()
    {
        yield return new WaitForSeconds(12.5f);
        print("next scene");
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

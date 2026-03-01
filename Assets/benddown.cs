using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class benddown : MonoBehaviour
{
    public AnimatorController animcon;

    public GameObject canvas2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(playAnim());
    }

    IEnumerator playAnim()
    {
       yield return new WaitForSeconds(4.5f);
        GetComponent<Animator>().runtimeAnimatorController = animcon;
        
        yield return new WaitForSeconds(4);
        canvas2.SetActive(true);
        
        yield return new WaitForSeconds(3.5f);
        print("next scene");
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

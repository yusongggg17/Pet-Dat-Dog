using UnityEngine;

public class WinScreenSpin : MonoBehaviour
{
    private float rotateSpeed = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}

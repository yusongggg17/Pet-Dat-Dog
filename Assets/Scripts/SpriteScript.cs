using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    [SerializeField] public Camera cam;
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation=cam.transform.rotation;
    }
}

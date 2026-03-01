using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    [SerializeField] public Camera cam;
    void Start()
    {
        transform.rotation = cam.transform.rotation;
        transform.position += transform.forward * -2f;
    }

    void Update()
    {
        transform.rotation=cam.transform.rotation;
    }
}

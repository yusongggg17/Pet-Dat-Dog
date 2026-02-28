using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Grid : MonoBehaviour
{
    public enum tiles { grass, water, sand, rock, empty };
    public int[,] level = {
        {(int)tiles.grass,(int)tiles.water,(int)tiles.sand},
        {(int)tiles.grass,(int)tiles.sand,(int)tiles.rock},
        {(int)tiles.sand,(int)tiles.grass,(int)tiles.water}
    };
    void Start()
    {
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                //
            }
        }
    }
    void Update()
    {
        
    }
    public void OnMove(InputActionReference moveDirection)
    {
        Vector2 dir = moveDirection.action.ReadValue<Vector2>();
        Debug.Log(dir);
    }
}

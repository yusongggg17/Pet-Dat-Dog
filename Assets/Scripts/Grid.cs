using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Grid : MonoBehaviour
{
    public enum tiles { grass, water, sand, rock, empty };
    public int playerX;
    public int playerY;
    public bool isMoving;
    public int[,] level = {
        {(int)tiles.grass,(int)tiles.water,(int)tiles.sand},
        {(int)tiles.grass,(int)tiles.sand,(int)tiles.rock},
        {(int)tiles.sand,(int)tiles.grass,(int)tiles.water}
    };
    void Start()
    {
        playerX = 0;
        playerY = 0;
        isMoving = false;
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
        if (isMoving) return;
        int newX = playerX;
        int newY = playerY;
        Vector2 v = moveDirection.action.ReadValue<Vector2>();
        switch (v)
        {
            case Vector2 v2 when v2 == Vector2.up:
                newY += 1;
                break;
            case Vector2 v2 when v2 == Vector2.down:
                newY -= 1;
                break;
            case Vector2 v2 when v2 == Vector2.left:
                newX -= 1;
                break;
            case Vector2 v2 when v2 == Vector2.right:
                newX += 1;
                break;
            default:
                return;
        }
        if (canGoto(newX, newY))
        {
            playerX = newX;
            playerY = newY;
            StartCoroutine("Animate");
            print("Moved to: " + playerX + ", " + playerY);
        }
    }
    public IEnumerator Animate()
    {   
        isMoving = true;
        yield return new WaitForSeconds(0.5f);
        isMoving = false;
    }
    public bool canGoto(int x, int y)
    {
        if (x < 0 || x >= level.GetLength(0) || y < 0 || y >= level.GetLength(1)) return false;
        if (level[x, y] == (int)tiles.empty) return false;
        return true;
    }
}

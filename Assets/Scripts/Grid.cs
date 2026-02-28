using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;
using System.Net;
public class Grid : MonoBehaviour
{
    public enum tiles { jump, blind, slow, child, car, cone, road, empty };
    [SerializeField] public GameObject jumpTile;
    [SerializeField] public GameObject blindTile;
    [SerializeField] public GameObject slowTile;
    [SerializeField] public GameObject childTile;
    [SerializeField] public GameObject carTile;
    [SerializeField] public GameObject coneTile;
    [SerializeField] public GameObject roadTile;    
    public int playerX;
    public int playerY;
    public int originX;
    public int originY;
    public int tileSize = 4;
    public bool isMoving;
    public int[,] level = {
        {(int)tiles.road,(int)tiles.cone,(int)tiles.cone},
        {(int)tiles.road,(int)tiles.road,(int)tiles.empty},
        {(int)tiles.road,(int)tiles.jump,(int)tiles.road},
        {(int)tiles.road,(int)tiles.empty,(int)tiles.empty},
        {(int)tiles.road,(int)tiles.road,(int)tiles.empty}
    };
    void Start()
    {
        playerX = 1;
        playerY = 1;
        originX=0;
        originY=0;
        Vector3 p=transform.position;
        p.x = originX + playerX * tileSize;
        p.z = originY + playerY * tileSize;
        transform.position = p;
        isMoving = false;
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                GameObject tile = null;
                switch (level[i,j])
                {
                    case (int)tiles.empty:
                        continue;
                    case (int)tiles.jump:
                        tile = Instantiate(jumpTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                    case (int)tiles.blind:
                        tile = Instantiate(blindTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                    case (int)tiles.slow:
                        tile = Instantiate(slowTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                    case (int)tiles.child:
                        tile = Instantiate(childTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                    case (int)tiles.car:
                        tile = Instantiate(carTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                    case (int)tiles.cone:
                        tile = Instantiate(coneTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                    case (int)tiles.road:
                        tile =Instantiate(roadTile, new Vector3(originX + i * tileSize, 0, originY + j * tileSize), Quaternion.identity);
                        break;
                }
                tile.SetActive(true);
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
        if(canGoto(newX, newY) && level[newX, newY] == (int)tiles.jump)
        {
            if (canGoto(newX + (newX - playerX), newY + (newY - playerY)))
            {
            newX += (newX - playerX);
            newY += (newY - playerY);
            playerX = newX;
            playerY = newY;
            StartCoroutine(Animate(newX, newY));
            print("Moved to: " + playerX + ", " + playerY);
            }
        }
        else if (canGoto(newX, newY))
        {
            playerX = newX;
            playerY = newY;
            StartCoroutine(Animate(newX, newY));
            print("Moved to: " + playerX + ", " + playerY);
        }
    }
    public IEnumerator Animate(int newX, int newY)
    {   
        isMoving = true;
        float elapsed = 0;
        Vector3 p=transform.position;
        Vector3 p0=p;
        p.x = originX + newX * tileSize;
        p.z = originY + newY * tileSize;
        DateTime startTime = DateTime.Now;
        while(elapsed < 0.25f)
        {
            elapsed+=Time.deltaTime;
            transform.position = Vector3.Lerp(p0, p, (float)elapsed / 0.25f);
            yield return null;
        }
        print("Animation took " + (DateTime.Now - startTime).TotalMilliseconds + " milliseconds");
        transform.position = p;
        isMoving = false;
        StopCoroutine(Animate(newX, newY));
    }
    public bool canGoto(int x, int y)
    {
        if (x < 0 || x >= level.GetLength(0) || y < 0 || y >= level.GetLength(1)) return false;
        if (level[x, y] == (int)tiles.empty||level[x, y] == (int)tiles.cone||level[x, y] == (int)tiles.car) return false;
        return true;
    }
}
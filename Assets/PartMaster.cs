using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = UnityEngine.Random;

public class PartMaster : MonoBehaviour
{
    public GameObject block;
    private bool[,] Occupied = new bool[5,5];
    private MapManager manager;
    private int placed = 0;


    public void Awake()
    {
        manager = GameObject.Find("/GameMaster").GetComponent<MapManager>();
        Generate(Random.Range(1,5));
        
    }

    private void Generate(int n)
    {
        int iterations = 0;
        while (placed<n&&iterations<10000)
        {
            iterations++;
            var x = Random.Range(-1, 2);
            x *= 2;
            var y = Random.Range(0, 2);
            y *= 2;
            PlaceNewPart(x,y,true);
        }
    }
    

    public void PlaceNewPart(int x, int y, bool startup)
    {
        if (Occupied[x+2,y+2])
        {
            return;
        }

        
        if(!startup)
            manager.ResetTarget();

        placed++;
        
        if (placed >= 6)
        {
            manager.SpawnNewTarget();
        }
        

        Occupied[x+2, y+2] = true;
        Vector3 pos = transform.position;
        pos.x += x;
        pos.y += y;
        GameObject go = Instantiate(block, pos, Quaternion.identity);
        go.transform.SetParent(transform);
    }
}

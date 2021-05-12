using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 6;
    public int cols = 6;
    private float tilesize = 1;
 
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("tilessol"));
        for (int row = 0; row < rows; row++)
        {
            for(int col =0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                float posX = col * tilesize;
                float posY = row * -tilesize;
                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

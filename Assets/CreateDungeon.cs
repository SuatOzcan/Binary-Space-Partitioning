using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDungeon : MonoBehaviour
{
    public int mapWidth = 50;
    public int mapDepth = 50;
    public int scale = 2;
    Leaf root;
    Leaf left;
    Leaf right;
    // Start is called before the first frame update
    void Start()
    {
        root = new Leaf(0, 0, mapWidth, mapDepth, scale);
       // root.Draw();
        left = new Leaf(0, 0, mapWidth / 2, mapDepth / 2, scale);
        right = new Leaf(mapWidth/2, 0, mapWidth / 2, mapDepth / 2, scale);
        left.Draw();
        right.Draw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

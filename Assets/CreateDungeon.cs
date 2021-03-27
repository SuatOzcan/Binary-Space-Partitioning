using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDungeon : MonoBehaviour
{
    public int mapWidth = 50;
    public int mapDepth = 50;
    public int  scale = 2;
    Leaf root;
    Leaf left;
    Leaf right;
    // Start is called before the first frame update
    void Start()
    {
        root = new Leaf(0, 0, mapWidth, mapDepth, scale);
        // root.Draw();
        //root.Split();
        BSP(root, 3);
      /*int l1width = Random.Range((int)(mapWidth * 0.1), (int)(mapWidth * 0.7));
        left = new Leaf(0, 0, l1width , mapDepth, scale);
        right = new Leaf(l1width, 0, (mapWidth-l1width), mapDepth, scale);
        left.Draw();
        right.Draw();*/
    }

    void BSP(Leaf l, int sDepth)
    {
        if (l == null) return;
        if (sDepth <= 0) return;
        //l.Draw();
        if (l.Split(sDepth))
        {
            BSP(l.leftChild, sDepth - 1);
            BSP(l.rightChild, sDepth - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf
{   public int xpos;
    public int zpos;
    public int width;
    public int depth;
    public int scale;

    int roomMin = 5;

    public Leaf leftChild;
    public Leaf rightChild;

    public Leaf(int x, int z, int w, int d, int s)
    {
        xpos = x;
        zpos = z;
        width = w;
        depth = d;
        scale = s;
    }

    public bool Split()
    {
        if (width <= roomMin || depth <= roomMin) return false;
        bool splitHorizontal = Random.Range(0, 100) > 50;
        if (width > depth && width / depth >= 1.2)
            splitHorizontal = false;
        else if (depth > width && depth / width >= 1.2)
            splitHorizontal = true;

        int max = (splitHorizontal ? depth : width) - roomMin;
        if (max <= roomMin) return false;

        if (splitHorizontal)
        {
            int l1depth = Random.Range(roomMin, max);
            leftChild = new Leaf(xpos, zpos, width, l1depth, scale);
            rightChild = new Leaf(xpos, zpos + l1depth, width, (depth - l1depth), scale);
        }
        else
        {
            int l1width = Random.Range(roomMin, max);
            leftChild = new Leaf(xpos, zpos, l1width, depth, scale);
            rightChild = new Leaf(xpos + l1width, zpos, (width - l1width), depth, scale);
        }


        //leftChild.Draw();
        //rightChild.Draw();

        return true;
    }

    public void Draw(byte[,] map)
    {
        Color c = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        for (int x = xpos; x < width + xpos; x++)      
            for (int z = zpos; z < depth + zpos; z++)
            {
                GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.position = new Vector3(x * scale, 0, z * scale);
                Cube.transform.localScale = new Vector3(scale, scale, scale);
                Cube.GetComponent<Renderer>().material.SetColor("_Color", c);
            }

        for (int x = xpos + 1; x < width +xpos - 1; x++)
        {
            for (int z = zpos + 1; z < depth+ zpos - 1; z++)
            {
                map[x, z] = 0;
            }
        }
    }
}

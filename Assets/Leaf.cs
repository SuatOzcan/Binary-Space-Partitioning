using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf
{   int xpos;
    int zpos;
    int width;
    int depth;
    int scale;

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
        if (Random.Range(0,100)<50)
        {
            int l1depth = Random.Range((int)(depth * 0.1), (int)(depth * 0.7));
            leftChild = new Leaf(xpos, zpos, width, l1depth, scale);
            rightChild = new Leaf(xpos, zpos + l1depth, width, (depth - l1depth), scale);
        }
        else
        {
            int l1width = Random.Range((int)(width * 0.1), (int)(width * 0.7));
            leftChild = new Leaf(xpos, zpos, l1width, depth, scale);
            rightChild = new Leaf(xpos + l1width, zpos, (width - l1width), depth, scale);
        }


        //leftChild.Draw();
        //rightChild.Draw();

        return true;
    }

    public void Draw(int level)
    {
        Color c = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        for (int x = xpos; x < width + xpos; x++)      
            for (int z = zpos; z < depth + zpos; z++)
            {
                GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.position = new Vector3(x * scale, level * 3, z * scale);
                Cube.transform.localScale = new Vector3(scale, scale, scale);
                Cube.GetComponent<Renderer>().material.SetColor("_Color", c);
            }
    }
}

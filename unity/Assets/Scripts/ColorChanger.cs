using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger: MonoBehaviour
{
    public MeshRenderer rend;
    public Material[] mats;
    public int cur;

    // Start is called before the first frame update
    void Start()
    {
        if (rend == null)
        {
            rend = GetComponent<MeshRenderer>();
        }
    }

    public void Increment()
    {
        if (mats != null && mats.Length > 0)
        {
            cur = (cur + 1) % mats.Length;
            if (rend != null)
            {
                rend.material = mats[cur];
            }
        }
    }

    public void RandomColor()
    {
        rend.material.color = UnityEngine.Random.ColorHSV();
    }
}

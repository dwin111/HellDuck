using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductGenerator : Generator
{
    protected override void Spawn()
    {
        Products[_manager.HowMuchIsNow].SetActive(true);
    }

    public override void DellProduct()
    {
        if (_manager.HowMuchIsNow >= 0)
            Products[_manager.HowMuchIsNow].SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProductGenerator : Generator
{
    [SerializeField] private GameObject _prefab;
    protected override void Spawn()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-1.5f, 1.5f), 0, Random.Range(-1.5f, 1.5f));
        GameObject obj = Instantiate(_prefab, transform.position + randomPosition, transform.rotation, transform);
        Products.Add(obj);
    }
    public override void DellProduct()
    {
        if (_manager.HowMuchIsNow > 0)
        {
            Destroy(Products[_manager.HowMuchIsNow - 1]);
            Products.RemoveAt(_manager.HowMuchIsNow - 1);
        }
        else if (_manager.HowMuchIsNow == 0)
        {
            foreach (var item in Products)
            {
                Destroy(item);
            }
            Products.Clear();
        }

    }
}

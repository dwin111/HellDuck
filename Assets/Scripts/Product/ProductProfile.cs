using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Product/Profile")]
public class ProductProfile : ScriptableObject
{
    public GameObject Perfab;
    public ThePickerOfAllGoods.Product Name;
    public int Count;
}

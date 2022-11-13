using System.Linq;
using UnityEngine;

public class ProductFilling : MonoBehaviour
{
    private void Awake()
    {
        ProductStorage.Instance.ProductSample = Resources.LoadAll<ProductProfile>("Product/").ToList();
    }
}

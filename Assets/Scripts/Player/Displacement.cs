using System.Collections.Generic;
using UnityEngine;

public class Displacement : MonoBehaviour
{  
    [SerializeField] float _shifTo;
    [SerializeField] float shift;
    [SerializeField] private List<GameObject> _indicationProduct;

    private FoodCollection _foodCollection;
    private int _lastIndexProduct = 0;

    private void Start()
    {
        _foodCollection = GetComponent<FoodCollection>();
    }

    void Update()
    {
        if (_foodCollection.Product.Count != _lastIndexProduct)
        {
            foreach (var item in _indicationProduct)
            {
                Destroy(item.gameObject);
            }
            _indicationProduct.Clear();
            _lastIndexProduct = 0;

            shift = 0;
            foreach (var item in _foodCollection.Product)
            {
                GameObject product = Instantiate(item.Perfab, transform);
                product.transform.position = new Vector3(product.transform.position.x, product.transform.position.y + shift, product.transform.position.z);

                _indicationProduct.Add(product);
                shift += _shifTo;
                _lastIndexProduct++;
            }
        }
    }
    
}

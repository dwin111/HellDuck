using UnityEngine;

public class ProductShop : ProductDelivery
{

    private ProductsCollicting _collicting;
  
    private void Start()
    {
        _collicting = GetComponent<ProductsCollicting>();   
        DataStore.Instance.AllShop.Add(this.gameObject);
    }
    private void FixedUpdate()
    {
        if(_collicting.NumProduckt != _howMuchIsNow)
        {
            _collicting.NumProduckt = _howMuchIsNow;
        }
    }
}

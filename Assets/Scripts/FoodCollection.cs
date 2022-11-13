using System.Collections.Generic;
using UnityEngine;

public class FoodCollection : MonoBehaviour
{
    [SerializeField] private int _maxNumberProduct;

    public int MaxNumberProduct { get => _maxNumberProduct; set => _maxNumberProduct = value; }
    public float DounSpeedTime { get => _dounSpeedTime; set => _dounSpeedTime = value; }

    public List<ProductProfile> Product = new List<ProductProfile>();
    private float _timer = 0;
    private float _dounSpeedTime = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ProductPublisher")
        {
            ProductDelivery _productDelivery = other.gameObject.GetComponent<ProductDelivery>();
            foreach (var product in ProductStorage.Instance.ProductSample)
            {
                ProductAdd(product.Name, product, _productDelivery);
            }
        }
        if (other.gameObject.tag == "ProductPublisherBuyer" && this.gameObject.tag == "Buyer")
        {
            ProductDelivery _productDelivery = other.gameObject.GetComponent<ProductDelivery>();
            foreach (var product in ProductStorage.Instance.ProductSample)
            {
                ProductAdd(product.Name, product, _productDelivery);
            }
        }
    }
    public void ProductAdd(ThePickerOfAllGoods.Product cellProduct, ProductProfile product, ProductDelivery productPublisher)
    {
        if (productPublisher.SelectedProduct == cellProduct && productPublisher.HowMuchIsNow > 0 && productPublisher.HowMuchIsNow <= productPublisher.MaxProducts && Product.Count < _maxNumberProduct)
        {
            _timer += Time.deltaTime;
            if (_timer >= productPublisher.IssuindTime - _dounSpeedTime)
            {
                _timer = 0;
                Product.Add(product);
                productPublisher.HowMuchIsNow--;
                if((productPublisher).UEvent != null)
                    (productPublisher).UEvent.Invoke();   

            }
        }

    }
}

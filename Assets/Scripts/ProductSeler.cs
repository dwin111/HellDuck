using System.Collections.Generic;
using UnityEngine;

public class ProductSeler : MonoBehaviour, ISelected
{
    [SerializeField] protected ThePickerOfAllGoods.Product _selectedProduct;
    [SerializeField] protected FoodCollection _foodCollection;
    [SerializeField] protected float _money;
    [SerializeField] protected int _numProduckt;
    [SerializeField] protected float _salesTime;
    [SerializeField] protected List<GameObject> ProducktGameObject;
    [SerializeField] protected float _issuindTime;

    protected DataStore _data;
    public ThePickerOfAllGoods.Product SelectedProduct { get => _selectedProduct; }
    public int NumProduckt { get => _numProduckt; }

    [SerializeField] protected Improvement _improvement;

    protected bool _isWork;
    protected int _maxProduckt;
    protected float _time = 0;
    protected float _time2 = 0;

    void Start()
    {
        _maxProduckt = ProducktGameObject.Count;
        _data = DataStore.Instance;
    } 

    protected void CollectionOfProductsOnTime(Collider other)
    {
        _foodCollection = other.GetComponent<FoodCollection>();
        if (_numProduckt < _maxProduckt && _foodCollection.Product.Count > 0)
        {
            _time2 += Time.deltaTime;
            if (_time2 >= _issuindTime)
            {
                foreach (var product in ProductStorage.Instance.ProductSample)
                {
                    ProductCell(product.Name);
                }
                _time2 = 0;
            }
        }
    }
    protected void ProductCell(ThePickerOfAllGoods.Product product)
    {
        int shift = 1;
        for (int i = 0; i < _foodCollection.Product.Count; i++)
        {
            if (_foodCollection.Product[_foodCollection.Product.Count - shift].Name == product && (_selectedProduct == product))
            {
                _foodCollection.Product.RemoveAt(_foodCollection.Product.Count - shift);
                if (_numProduckt < ProducktGameObject.Count)
                {
                    _numProduckt++;
                    if (ProducktGameObject[_numProduckt - 1] != null)
                    {
                        ProducktGameObject[_numProduckt - 1].gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                shift++;
            }
        }
    }
}
    

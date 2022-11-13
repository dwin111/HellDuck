using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsCollicting : MonoBehaviour, ISelected
{
    [SerializeField] private ThePickerOfAllGoods.Product _selectedProduct;
    [SerializeField] private FoodCollection _foodCollection;
    [SerializeField] private float _money;
    [SerializeField] private int _numProduckt;
    [SerializeField] private float _salesTime;
    [SerializeField] private List<GameObject> ProducktGameObject;
    [SerializeField] private float _issuindTime;

    private DataStore _data;
    public ThePickerOfAllGoods.Product SelectedProduct { get => _selectedProduct; }
    public int NumProduckt { get => _numProduckt; set => _numProduckt = value; }

    [SerializeField] private Improvement _improvement;

    private bool _isWork;
    private int _maxProduckt;
    private float _time = 0;
    private float _time2 = 0;

    void Start()
    {
        _maxProduckt = ProducktGameObject.Count;
        _data = DataStore.Instance;
        if(gameObject.tag != "PayDeskMain")
            _data.AllCounts.Add(this.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && gameObject.tag != "PayDeskMain")
        {
            CollectionOfProductsOnTime(other);
        }
        if (other.gameObject.tag == "Buyer" && gameObject.tag == "PayDeskMain")
        {
            CollectionOfProductsOnTime(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            _isWork = false;
        }
        if (other.gameObject.tag == "Player")
        {
            _foodCollection = null;
        }
        if (other.gameObject.tag == "Buyer" && gameObject.tag == "PayDeskMain")
        {
            _foodCollection = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            _isWork = true;
        }
    }

    private void CollectionOfProductsOnTime(Collider other)
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
    private void ProductCell(ThePickerOfAllGoods.Product product)
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
    private void FixedUpdate()
    {
        if (_numProduckt > 0 && _isWork)
        {
            if (gameObject.tag != "PayDeskMain")
            {
                _time += Time.deltaTime;
                if (_time >= _salesTime)
                {
                    if (ProducktGameObject[_numProduckt - 1] != null)
                    {
                        ProducktGameObject[_numProduckt - 1].gameObject.SetActive(false);
                    }
                    _numProduckt--;
                    _data.AddMoney((_money + _improvement.AdderToMoney));
                    _time = 0;
                }
            }
            else
            {
                for (int i = 0; i < _numProduckt; i++)
                {
                    _numProduckt--;
                    ProducktGameObject[_numProduckt - 1].gameObject.SetActive(false);
                    _data.AddMoney((_money + _improvement.AdderToMoney));
                }
            }
        }
        else if (_time != 0)
        {
            _time = 0;
        }
    }

}

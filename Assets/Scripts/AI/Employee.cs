using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Employee : AI, ISelected
{
    [SerializeField] private ThePickerOfAllGoods.Product _selectedProduct;
    [SerializeField] private List<Transform> _transformPuts = new List<Transform>();    
    private FoodCollection _foodCollection;
    private int _countPut;

    public ThePickerOfAllGoods.Product SelectedProduct => _selectedProduct;

    private void Start()
    {
        _foodCollection = GetComponent<FoodCollection>();
        _numbeOfPickupPoints = _data.AllFerms.Count;
        _countPut = _data.AllFerms.Count;
        FillingAllTransformTake(_PickupPoints, _data.AllFerms);
        TakeCoordinates(ref _productTaking, _PickupPoints);

        FillingAllTransformTake(_transformPuts, _data.AllCounts);
        TakeCoordinates(ref _transformPut, _transformPuts);
    }
    private void FixedUpdate()
    {
        if(_numbeOfPickupPoints != _data.AllFerms.Count)
        {
            FillingAllTransformTake(_PickupPoints, _data.AllFerms);
            _numbeOfPickupPoints = _data.AllFerms.Count;
        }        
        if(_countPut != _data.AllCounts.Count)
        {
            FillingAllTransformTake(_transformPuts, _data.AllCounts);
            _countPut = _data.AllCounts.Count;
        }
        if (_state == 0)
        {
            _animator.SetBool("Run", true);
            Move(_productTaking);
        }
        else if (_state == 1)
        {
            _animator.SetBool("Run", true);
            Move(_transformPut);
        }
        else
        {
            _animator.SetBool("Run", false);
            _agent.isStopped = true;
            TakeCoordinates(ref _productTaking, _PickupPoints);
            TakeCoordinates(ref _transformPut, _transformPuts);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ProductPublisher")
        {
            timer += Time.deltaTime;
            if(timer >= _wakingTime)
            {
                _state = 1;
                timer = 0;
            }
        }
        else if (other.gameObject.tag == "ProductsCollecting" || other.gameObject.tag == "ProductPublisherBuyer" || other.gameObject.tag == "ProductPublisherBuyer")
        {
            timer += Time.deltaTime;
            if (timer >= _wakingTime)
            {
                _state = 0;
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "ProductPublisher" || other.gameObject.tag == "ProductsCollecting" || other.gameObject.tag == "ProductPublisherBuyer"))
        {
            _state = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ProductsCollecting" || other.gameObject.tag == "ProductPublisherBuyer")
        {
            timer = 0;
            TakeCoordinates(ref _productTaking, _PickupPoints);
            if (_foodCollection.Product.Count <= 0)
            {
                _state = 0;
            }
            else
            {
                _state = 1;
            }
        }
        if(other.gameObject.tag == "ProductPublisher")
        {
            timer = 0;
            TakeCoordinates(ref _transformPut, _transformPuts);
            if (_foodCollection.Product.Count <= 0)
            {
                _state = 0;
            }
            else
            {
                _state = 1;
            }
        }

    }
    private void FillingAllTransformTake(List<Transform> transforms, List<GameObject> list)
    {
        transforms.Clear();
        foreach (var item in list)
        {
            if (_selectedProduct == item.gameObject.GetComponent<ISelected>().SelectedProduct)
            {
                transforms.Add(item.transform);
             }
        }
    }


}

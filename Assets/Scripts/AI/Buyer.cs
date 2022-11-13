using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Buyer : AI
{
    [SerializeField] private Transform _transformExit;
    [SerializeField] private Transform _payDeskMain;
    [SerializeField] private int _killProduct;
    private int _oldKillProduct;
    public int State { get => _state; set => _state = value; }


    private void Start()
    {
        FillingAllTransformTake(_PickupPoints, _data.AllShop);
        _oldKillProduct = _killProduct;
        _transformExit = _data.Exit;
        _payDeskMain = _data.AllPayDesk[0];
        _numbeOfPickupPoints = _data.AllShop.Count;
    }

    private void FixedUpdate()
    {
        if(_productTaking == null)
        {
            TakeCoordinates(ref _productTaking, _PickupPoints);
        }
        if(_transformPut == null)
        {
            _transformPut = _payDeskMain;

        }
        if (_numbeOfPickupPoints != _data.AllShop.Count)
        {
            FillingAllTransformTake(_PickupPoints, _data.AllShop);
            _numbeOfPickupPoints = _data.AllShop.Count;
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
        else if (_state == 4)
        {
            _animator.SetBool("Run", true);
            Move(_transformExit);
        }
        else
        {
            _animator.SetBool("Run", false);
            _agent.isStopped = true;
            TakeCoordinates(ref _productTaking, _PickupPoints);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "ProductPublisherBuyer") || (other.gameObject.tag == "PayDeskMain"))
        {
            _state = 3;
        }
        if(other.gameObject.tag == "Exit")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "ProductPublisherBuyer"))
        {
            timer += Time.deltaTime;
            if (timer >= _wakingTime)
            {
                if (_oldKillProduct > 0)
                {
                    TakeCoordinates(ref _productTaking, _PickupPoints);
                    _state = 0;
                    timer = 0;
                    _oldKillProduct--;
                }
                else
                {
                    _state = 1;
                    timer = 0;
                }
            }
        }       
    }

    private void FillingAllTransformTake(List<Transform> transforms, List<GameObject> list)
    {
        transforms.Clear();
        foreach (var item in list)
        {
            transforms.Add(item.transform);
        }
    } 

}
using System.Collections.Generic;
using UnityEngine;
public class PayDeskMain : ProductSeler
{
    [SerializeField] private List<Buyer> _buyers;
    [SerializeField] private float _wakingTime;

    private float _timer = 0;

    public bool IsWork { get => _isWork;}
    private void Start()
    {
        DataStore.Instance.AllPayDesk.Add(this.transform);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Buyer" && gameObject.tag == "PayDeskMain")
        {
            CollectionOfProductsOnTime(other);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _isWork = true;
        }
        if(other.gameObject.tag == "Buyer")
        {
            _buyers.Add(other.gameObject.GetComponent<Buyer>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isWork = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isWork && _buyers.Count > 0)
        {
            _timer+=Time.deltaTime;
            if(_timer >= _wakingTime)
            {
                _buyers[0].State = 4;
                _buyers.RemoveAt(0);
                _timer = 0;
                for (int i = 0; i < _numProduckt; i++)
                {
                    _numProduckt--;
                    ProducktGameObject[_numProduckt - 1].gameObject.SetActive(false);
                    _data.AddMoney((_money + _improvement.AdderToMoney));
                }
            }
        }

    }





}

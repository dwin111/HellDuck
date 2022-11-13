using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private float _price;
    [SerializeField] private long _increaseTheCostBy;
    [SerializeField] private int _maximumPurchase;
    [SerializeField] private Button _button;
    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textName;
    [SerializeField] private Text _textPurchase;

    [SerializeField] private long _purchase;

    public UnityEvent UnityEvent;


    private DataStore _data;

    public long Purchase { get => _purchase; set { _purchase = value; } }

    public float Price { get => _price; set => _price = value; }

    void Start()
    {
        UpadeData();
        _button.enabled = false;
        _data = DataStore.Instance;
        _textScore.text = _price.ToString();
        _textPurchase.text = _purchase + "/" + _maximumPurchase;

    }

    void Update()
    {
        UpadeData();
        if (_data.AllMoney < _price && _maximumPurchase <= _purchase)
        {
            _button.enabled = false;
        }
        else if (_data.AllMoney >= _price && _maximumPurchase > _purchase)
        {
            _button.enabled = true;
        }
        else
        {
            _button.enabled = false;
        }
    }
    public void Cell()
    {
        _data.ÑashiWthdrawal(_price);
        if(UnityEvent != null) UnityEvent.Invoke();
        _purchase++;
        _price += _increaseTheCostBy;
        _textScore.text = _price.ToString();
        _textPurchase.text = _purchase + "/" + _maximumPurchase;
    }
    public void UpadeData()
    {
        if (UnityEvent != null) UnityEvent.Invoke();
        _textScore.text = _price.ToString();
        _textPurchase.text = _purchase + "/" + _maximumPurchase;
    }
}

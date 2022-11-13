using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnCub : MonoBehaviour
{
 
    [SerializeField] private GameObject _spawnGameObject;
    [SerializeField] private float _price;
    [SerializeField] private float _delay = 2;
    private TextMeshPro _textScore;
    private DataStore _data;
    private float _number = 1;
    [SerializeField]  private float _buffer;
    private float _timer = 0;
    public UnityEvent FlfillAfterPurchase;

    private void Awake()
    {
        _data = DataStore.Instance;
        _textScore = GetComponentInChildren<TextMeshPro>();
        _textScore.text = _price.ToString();
        _spawnGameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer >= _delay)
            {
                Buy();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = 0;
        }
    }
    public void Buy()
    {
        if (_price <= _buffer)
        {
            _data.ÑashiWthdrawal(_price);
            _spawnGameObject.SetActive(true);      
            if(FlfillAfterPurchase != null)
            {
                FlfillAfterPurchase.Invoke();
            }
            this.gameObject.SetActive(false);
        }
        else if (_data.AllMoney >= _number)
        {
            _buffer += _number;
            _data.ÑashiWthdrawal(_number);
            _textScore.text = (Convert.ToSingle(_textScore.text) - _number).ToString();
        }
    }
}

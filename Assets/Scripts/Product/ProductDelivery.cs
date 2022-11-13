using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ProductDelivery : MonoBehaviour , ISelected
{
    [SerializeField] private ThePickerOfAllGoods.Product _selectedProduct;
    [SerializeField] private float _issuindTime;
    [SerializeField] private int _maxProducts;
    [SerializeField] protected int _howMuchIsNow;

    public UnityEvent UEvent;
    public ThePickerOfAllGoods.Product SelectedProduct { get => _selectedProduct; }
    public int MaxProducts { get => _maxProducts; }
    public int HowMuchIsNow { get => _howMuchIsNow; set { if (value < 0) _howMuchIsNow = 0; else _howMuchIsNow = value; } }
    public float IssuindTime { get => _issuindTime; }

}

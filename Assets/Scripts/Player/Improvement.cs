using System.Collections.Generic;
using UnityEngine;

public class Improvement : MonoBehaviour
{
    [SerializeField] private int _addMon = 0;
    public int AdderToMoney { get => _addMon; set => _addMon = value; }
    private FoodCollection _foodCollection;
    private PhysicsMovement _physicsMovement;
    private InformationToSave _saveInfo;

    [SerializeField] private List<Buy> _allBuy;
    private void Start()
    {
        _saveInfo = DataStore.Instance.InformationToSave;
        _foodCollection = GetComponent<FoodCollection>();
        _physicsMovement = GetComponent<PhysicsMovement>();
        Load();
    }
    public void Lifting()
    {
        _foodCollection.MaxNumberProduct++;
        _saveInfo.MaxNumberProduct = _foodCollection.MaxNumberProduct;
        SaveNumberOfBuy(0);
    }
    public void UpSpeed()
    {
        _physicsMovement.Speed += (_physicsMovement.Speed / 30);
        _saveInfo.Speed = _physicsMovement.Speed;
        SaveNumberOfBuy(1);
    }
    public void UpSpeedCollecktion()
    {
        _foodCollection.DounSpeedTime -= (_foodCollection.DounSpeedTime / 10);
        _saveInfo.DounSpeedTime = _foodCollection.DounSpeedTime;
        SaveNumberOfBuy(2);
    }
    public void UpMoney()
    {
        _addMon++;
        _saveInfo.AddMon = _addMon;
        SaveNumberOfBuy(3);
    }
    private void SaveNumberOfBuy(int index)
    {
        _saveInfo.NumberOfUpdate[index]++;
        _saveInfo.ValueUpdate[index] = _allBuy[index].Price;

    }
    private void Load()
    {
        if ((_saveInfo.MaxNumberProduct != 0 || _saveInfo.DounSpeedTime != 0 ||_saveInfo.AddMon != 0) && _saveInfo.Speed != 0)
        {
            _foodCollection.MaxNumberProduct = _saveInfo.MaxNumberProduct;
            _physicsMovement.Speed = _saveInfo.Speed;
            _foodCollection.DounSpeedTime = _saveInfo.DounSpeedTime;
            _addMon = _saveInfo.AddMon;
            for (int i = 0; i < _allBuy.Count; i++)
            {
                 _allBuy[i].Price += _saveInfo.ValueUpdate[i];
                _allBuy[i].UpadeData();
            }
            for (int i = 0; i < _allBuy.Count; i++)
            {
                _allBuy[i].Purchase += _saveInfo.NumberOfUpdate[i];
                _allBuy[i].UpadeData();
            }
        }
    }
}

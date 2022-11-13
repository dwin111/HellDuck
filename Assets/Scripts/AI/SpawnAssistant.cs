using UnityEngine;
using UnityEngine.UI;
public class SpawnAssistant : MonoBehaviour
{
    [SerializeField] private ThePickerOfAllGoods.Product product;
    [SerializeField] private GameObject _assistant;
    [SerializeField] private Buy _buttonBuy;
    private int _numberOfAssistants;

    private void Start()
    {
        if (product == ThePickerOfAllGoods.Product.Apple)
        {
            _numberOfAssistants = DataStore.Instance.InformationToSave.NumberOfAssistantsInApple;
        }
        if (product == ThePickerOfAllGoods.Product.Ñabbage)
        {
            _numberOfAssistants = DataStore.Instance.InformationToSave.NumberOfAssistantsInCabbage;
        }
        for (int i = 0; i < _numberOfAssistants; i++)
        {
            Instantiate(_assistant, transform.position, transform.rotation, transform);
        }
        _buttonBuy.Purchase = _numberOfAssistants;

    }

    public void Spawn()
    {
        Instantiate(_assistant, transform.position, transform.rotation, transform);
        _numberOfAssistants++;
        if (product == ThePickerOfAllGoods.Product.Apple) 
        {
            DataStore.Instance.InformationToSave.NumberOfAssistantsInApple = _numberOfAssistants;
        }
        if (product == ThePickerOfAllGoods.Product.Ñabbage)
        {
            DataStore.Instance.InformationToSave.NumberOfAssistantsInCabbage = _numberOfAssistants;
        }

    }
}

using UnityEngine;

public class TaxSystem : MonoBehaviour
{

    [SerializeField] private bool _taxIncluded;
    [SerializeField] private float _taxDeductionTime;
    [SerializeField] private float _sizeTax;

    private DataStore _data;
    private float _timer = 0;


    private void Start()
    {
        _data = DataStore.Instance;
        _taxIncluded = _data.InformationToSave.TaxIncluded;
    }

    private void FixedUpdate()
    {
        if( _taxIncluded)
        {
            _timer += Time.deltaTime;
            if( _timer >= _taxDeductionTime)
            {
                _data.ÑashiWthdrawal(_sizeTax);
                _timer = 0;
            }
        }
    }

    public void ReverseTax()
    {
        _taxIncluded = !_taxIncluded;
        _data.InformationToSave.TaxIncluded = _taxIncluded;
        _data.InformationToSave.SizeTax = _sizeTax;
    }
        
}

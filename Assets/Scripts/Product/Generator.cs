using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] private float _issuindTime;
    public List<GameObject> Products;
    protected ProductPublisher _manager;
    private float timer = 0;

    private void Awake()
    {
        _manager = GetComponent<ProductPublisher>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= _issuindTime)
        {
            if (_manager.HowMuchIsNow < _manager.MaxProducts)
            {
                Spawn();
                timer = 0;
                _manager.HowMuchIsNow++;
            }
        }
    }

    protected abstract void Spawn();
    public abstract void DellProduct();
}

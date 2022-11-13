using UnityEngine;

public class Cheker : MonoBehaviour
{
    [SerializeField] private float _resize;
    [SerializeField] private float _speedUpIn;
    [SerializeField] private float _timeForChange;
    [SerializeField] private bool _changeObject;
    [SerializeField] private float _sizeX;

    private void Start()
    {
        _sizeX = transform.localScale.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _changeObject = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _changeObject = false;
        }
    }
    private void FixedUpdate()
    {
        if (_changeObject)
        {
            if (transform.localScale.x < _resize + _sizeX)
            {
                transform.localScale += new Vector3(_resize, 0, _resize) * (Time.deltaTime * _speedUpIn);
            }
        }
        if (!_changeObject)
        {
            if (transform.localScale.x > _sizeX)
            {
                transform.localScale -= new Vector3(_resize, 0, _resize) * (Time.deltaTime * _speedUpIn);
            }
        }
    }


}

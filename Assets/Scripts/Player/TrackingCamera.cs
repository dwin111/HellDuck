using UnityEngine;
using UnityEngine.UI;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smooth = 0.1f;
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -3);
    [SerializeField] private Slider _slider;
    [SerializeField] private float _value;
    private void Start()
    {
        _value = _slider.value;
    }
    void Update()
    {
        if (_value < (int)_slider.value)
        { 
            offset += new Vector3(0, 1, -1);

            _value += 1;
        }
        else if (_value > (int)_slider.value)
        {
                offset -= new Vector3(0, 1, -1);

            _value -= 1;   
        }
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth);
    }
}

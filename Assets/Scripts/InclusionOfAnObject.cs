using UnityEngine;

public class InclusionOfAnObject : MonoBehaviour
{
    [SerializeField] private GameObject _firstObject;
    [SerializeField] private GameObject _secondObject;
    private bool _isActive = false;
    public bool IsActive => _isActive;

    public void OnFirstObject()
    {
        _firstObject.SetActive(true);
        _secondObject.SetActive(false);
        _isActive = true;
    }
    public void OffFirstObject()
    {
        _firstObject.SetActive(false);
        _secondObject.SetActive(true);
        _isActive = false;
    }
}

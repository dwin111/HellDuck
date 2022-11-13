using UnityEngine;

public class SliderOnOff : MonoBehaviour
{
    [SerializeField] private bool _included = false;

    public void OnOffSlider()
    {
        _included = !_included;
        this.gameObject.SetActive(_included);       
    }
    public void OffSlider()
    {
        _included = false;
        this.gameObject.SetActive(_included);
    }
}

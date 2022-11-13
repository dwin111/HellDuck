using UnityEngine;

public class SaleLine : MonoBehaviour
{   
    public void Start()
    {
        DataStore.Instance.AllSaleLine.Add(this.gameObject);
        GetComponent<InclusionOfAnObject>().OnFirstObject();
    }
}

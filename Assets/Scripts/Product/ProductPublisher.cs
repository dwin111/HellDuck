using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductPublisher : ProductDelivery
{
  
    private void Start()
    {
        DataStore.Instance.AllFerms.Add(this.gameObject);
        GetComponent<InclusionOfAnObject>().OnFirstObject();
    }
}

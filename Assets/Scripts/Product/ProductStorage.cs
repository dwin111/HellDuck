using System.Collections.Generic;
using UnityEngine;

public class ProductStorage
{

    private static ProductStorage _instance;
    public static ProductStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProductStorage();
            }
            return _instance;
        }
    }

    public List<ProductProfile> ProductSample;


}


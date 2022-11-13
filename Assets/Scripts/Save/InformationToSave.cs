using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InformationToSave 
{
    public float AllMoney;
    public float Speed;
    public float DounSpeedTime;
    public float SizeTax;

    public List<GameObject> AllFerms;
    public List<GameObject> AllSaleLine;

    public int MaxPLayerProduct;
    public int NumberOfAssistantsInApple;
    public int NumberOfAssistantsInCabbage;
    public int MaxNumberProduct;
    public int AddMon;
    public int SliderValue;


    public int[] Date = new int[6];
    public long[] NumberOfUpdate = new long[4];

    public float[] ValueUpdate = new float[4];


    public bool TaxIncluded;

}

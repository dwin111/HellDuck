using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataStore : MonoBehaviour
{
    public static DataStore Instance = null;
    [SerializeField] private Text _textMesh;
    [SerializeField] private float _allMoney = 0;
    [SerializeField] private bool _keep;
    [SerializeField] private float _bonus;

    public List<GameObject> AllFerms = new List<GameObject>();
    public List<GameObject> AllCounts = new List<GameObject>();
    public List<GameObject> AllShop = new List<GameObject>();
    public List<GameObject> AllSaleLine = new List<GameObject>();
    public List<Transform> AllPayDesk = new List<Transform>();

    public Transform Exit;
    public float AllMoney => _allMoney;
    public bool Keep { get => _keep; set => _keep = value; }

    private string _key = "DataStore";

    public InformationToSave InformationToSave = new InformationToSave();
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);      
    }
    private void Start()
    {
        Load();

        DateTime date = new DateTime(InformationToSave.Date[0], InformationToSave.Date[1], InformationToSave.Date[2], InformationToSave.Date[3], InformationToSave.Date[4], InformationToSave.Date[5]);
        TimeSpan ts = DateTime.Now - date;

        float oflineErnings = (float)Math.Round(((int)ts.TotalSeconds * (InformationToSave.NumberOfAssistantsInApple + InformationToSave.NumberOfAssistantsInCabbage) * _bonus));
        if (InformationToSave.TaxIncluded)
            AddMoney(oflineErnings - (oflineErnings * InformationToSave.SizeTax));
        else
            AddMoney(oflineErnings);

        print(oflineErnings);
    }
    private void OnDisable()
    {
        if (_keep)
        {
            Save();
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if (_keep && pause)
        {
            Save();
        }
    }
    public void AddMoney(float money)
    {
        _allMoney += money;
        UpdateData();
    }
    public void ÑashiWthdrawal(float money)
    {
        if (_allMoney > 0 && _allMoney - money >= 0)
        {
            _allMoney -= money;
        }
        UpdateData();
    }
    private void UpdateData()
    {    
        _textMesh.text = _allMoney.ToString();

        InformationToSave.AllFerms.Clear();

        InformationToSave.AllSaleLine.Clear();

        InformationToSave.AllMoney = _allMoney;

        for (int i = 0; i < AllFerms.Count; i++)
        {
            InformationToSave.AllFerms.Add(AllFerms[i]);
        }
        for (int i = 0; i < AllSaleLine.Count; i++)
        {
            InformationToSave.AllSaleLine.Add(AllSaleLine[i]);
        }
    }
    private void Save()
    {
        InformationToSave.Date[0] = DateTime.Now.Year;
        InformationToSave.Date[1] = DateTime.Now.Month;
        InformationToSave.Date[2] = DateTime.Now.Day;
        InformationToSave.Date[3] = DateTime.Now.Hour;
        InformationToSave.Date[4] = DateTime.Now.Minute;
        InformationToSave.Date[5] = DateTime.Now.Second;

        JsonSaveSystem.Save<InformationToSave>(_key, InformationToSave);
        Debug.Log("Save is OK");
    }
    private void Load()
    {
        if (PlayerPrefs.HasKey(_key))
        {
            Debug.Log(PlayerPrefs.GetString(_key));
            InformationToSave = JsonSaveSystem.Load<InformationToSave>(_key);
            if (InformationToSave != null)
            {
                _allMoney = InformationToSave.AllMoney;
                AllFerms.Clear();
                AllSaleLine.Clear();

                for (int i = 0; i < InformationToSave.AllFerms.Count; i++)
                {
                    AllFerms.Add(InformationToSave.AllFerms[i]);
                }
                OnGameObject(AllFerms);
                for (int i = 0; i < InformationToSave.AllSaleLine.Count; i++)
                {

                    AllSaleLine.Add(InformationToSave.AllSaleLine[i]);
                }
               OnGameObject(AllSaleLine);
            }
            UpdateData();
        }
    }
    private void OnGameObject(List<GameObject> list)
    {
        if (list.Count > 0)
        {
            foreach (var item in list)
            {
                print("OK");
                item.SetActive(true);            
            }
        }
    }
}

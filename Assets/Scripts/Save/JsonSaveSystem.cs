using UnityEngine;

public static class JsonSaveSystem
{
    public static void Save<T>(string key, T data)
    {
        string jsonData = JsonUtility.ToJson(data,true);
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    public static T Load<T>(string key) where T : new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }
        else
        {
            return new T();
        }
    }
}

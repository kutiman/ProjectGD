using UnityEngine;
using System.Collections;

public class DataSaveContoller
{
    public void SaveObject(string key, object dataClass)
    {
        if (dataClass == null)
        {
            Debug.LogError("data is null");
            return;
        }
        string json = UnityEngine.JsonUtility.ToJson(dataClass);
        PlayerPrefs.SetString(key, json);
    }
    public T GetObject<T>(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            Debug.LogError("DataSaveContoller --> GetObject --> there is no key: " + key);
            return default;
        }
        string json = PlayerPrefs.GetString(key);
        T obj = JsonUtility.FromJson<T>(json);

        if (obj == null)
        {
            Debug.LogError("DataSaveContoller --> GetObject --> object came null from deserialization: " + key);
            return default;
        }
        return obj;
    }
}

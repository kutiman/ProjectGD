using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupsController 
{
    GameObject _currentPopup; 

    IViewContainers _viewContainers;
    public PopupsController(IViewContainers viewContainers)
    {
        _viewContainers = viewContainers;
    }
    // Addressables can be implemented here with not a lot of hassle
    // but for this occasion, I'll just load it from some Resources folder
    public GameObject CreatePopup(string prefabName)
    {
        GameObject obj = Resources.Load<GameObject>(prefabName);

        if (obj == null)
        {
            Debug.LogError(string.Format("PopupsController --> CreatePrefab --> {0} was not found", prefabName));
            return null;
        }
        // here we can implement some logic to either destroy or hide the last popups, if any
        // we can even make a queue of popups and decide for each what will be its behaviour regarding other popups
        // for now i'm just destroying it
        GameObject inst = GameObject.Instantiate(obj, _viewContainers.popupsContainer);
        if (_currentPopup != null)
        {
            Object.Destroy(_currentPopup);
        }
        _currentPopup = inst;
        return inst;
    }

    public void ClosePopup()
    {
        if (_currentPopup != null)
        {
            Object.Destroy(_currentPopup);
        }
    }
    
    public bool ClosePopup<T>()
    {
        var comp = _currentPopup.GetComponent<T>();
        if (comp != null)
        {
            ClosePopup();
            return true;
        }
        else
        {
            // no popup of type T was found
            return false;
        }
    }
}

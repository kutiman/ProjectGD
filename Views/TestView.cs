using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestView : MonoBehaviour
{
    [SerializeField] Button _createPopupButton;

    private void Start()
    {
        _createPopupButton.onClick.AddListener(CreateImportantView);
        string objKey = "imp";

        // testing the saving and loading controller

        // print any old models
        SavaDataTestModel loadedModel = App.C.dataSave.GetObject<SavaDataTestModel>(objKey);
        if (loadedModel != null)
        {
            Debug.Log(string.Format("loaded model is not null. date is {0}", loadedModel.dateText));
        }
        // maKE A NEW MODEL AND SAVE IT
        SavaDataTestModel newModel = new SavaDataTestModel
        {
            dateText = DateTime.Now.ToString()
        };
        App.C.dataSave.SaveObject(objKey, newModel);
        Debug.Log("Object saved. time is: " + newModel.dateText);
    }

    void CreateImportantView() 
    {
        ImportantDataModel model = new ImportantDataModel
        {
            title = "WOW what a title!",
            subtitle = "this subtitle is almost better than the title"
        };

        ImportantView.Create(model);
    }
}

[Serializable]
public class SavaDataTestModel
{
    public string dateText;
}

using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportantView : MonoBehaviour
{
    // if using this method of calling the popup by name and not from references. 
    // i prefer referencing the prefabs to remove hardcoded strings
    const string prefabPath = "ImportantView";

    [SerializeField] TMPro.TMP_Text _title;
    [SerializeField] TMPro.TMP_Text _subtitle;
    [SerializeField] Button _btnStart;
    [SerializeField] Button _btnQuit;
    [SerializeField] Button _btnTellMeMore;

    ImportantDataModel _model;
    // a second Design Pattern i like. Dependency Inversion
    // in this case using a model, but for bigger things, using an interface
    // to implement data and functionality from other objects without knowledge of the source.
    // Dependency inversion make it easier to decouple code and create "plugable" modules
    public static ImportantView Create (ImportantDataModel model)
    {
        GameObject inst = App.C.popups.CreatePopup(prefabPath);
        var comp = inst.GetComponent<ImportantView>();
        if (comp != null)
        {
            comp.SetModel(model);
        }
        return comp;
    }
    public void SetModel(ImportantDataModel model)
    {
        _model = model;
    }
    private void Start()
    {
        if (_model == null)
        {
            Debug.LogError("ImportantView --> model is null");
        }

        // set the view
        _title.text = _model.title;
        _subtitle.text = _model.subtitle;

        _btnStart.onClick.AddListener(OnStartClick);
        _btnQuit.onClick.AddListener(OnQuitClick);
        _btnTellMeMore.onClick.AddListener(OnTellMeMoreClick);
    }

    void OnStartClick()
    {
        Debug.Log("Let's Start!");
    }
    void OnTellMeMoreClick()
    {
        Debug.Log("More, more and even MORE!");
    }
    void OnQuitClick()
    {
        Debug.Log("bye bye");
        App.C.popups.ClosePopup<ImportantView>();
    }
}

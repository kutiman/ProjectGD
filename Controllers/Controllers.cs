using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers
{
    PopupsController _popups;
    DataSaveContoller _dataSave;

    public PopupsController popups => _popups;
    public DataSaveContoller dataSave => _dataSave;
    public Controllers()
    {
        // all needed controllers created here
        _popups = new PopupsController(App.instance);
        _dataSave = new DataSaveContoller();
    }
}

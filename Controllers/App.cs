using UnityEngine;
using System.Collections;
/// <summary>
/// This is one of the design patterns I like, the Service Locator
/// It keeps everything organized and easier to keep decoupled
/// referencing all the services, especially in small-medium applications,
/// is worth while and makes development much faster i believe.
/// 
/// Service locator and a static persistent monobehaviour 
/// anything that relates to startup can be placed here
/// any data files that are app specific, etc.
/// </summary>
public class App : MonoBehaviour, IViewContainers
{
    // IViewContainers should be implemented in the Views class, with all other view references. for now it is good here...
    [SerializeField] Transform _popupsContainer;

    static App _instance;
    // declare models
    // declare views
    public static Controllers C { get; private set; }

    public static App instance => _instance;
    public Transform popupsContainer => _popupsContainer;

    private void Awake()
    {
        #region Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion

        #region MVC
        // create models
        // create views
        C = new Controllers();
        #endregion
    }
}

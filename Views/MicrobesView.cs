using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class MicrobesView : MonoBehaviour
{
    // we can just put all the microbes under a parent and this will make the list redundant.
    // also, GetComponents is much faster than Linq FindAll, since all components are cached by unity
    // somthing like parent.GetComponents<Microbe>() and iterating on that is easier and less prone to lost references errors
    [SerializeField] Transform _microbesParent;
    [SerializeField] Text _text;

    List<Microbe> _microbes;
    float totalHealth = 0f; // total health should be outside
    private void Start()
    {
        _microbes = _microbesParent.GetComponentsInChildren<Microbe>().ToList();
    }
    void FixedUpdate()
    {
        totalHealth = _microbes.Sum(m => m.Health);
        string text = string.Format("Total microbes: {0} Avg health {1}", _microbes.Count, totalHealth / _microbes.Count); // it was reversed
        _text.text = text; // better to cache it, though GetComponent is already cached and it is n(1) to call for GetComponent. check deep profiling and see. but still better
        Debug.Log(text);
    }
}

// BAD CODE 
/*
public class MicrobesView : MonoBehaviour
{
    [SerializedField] private List<Transform> _microbes;
    void FixedUpdate()
    {
        float totalHealth = 0f;
        foreach (Transform microbesTransform in _microbes)

        {
            Microbe microbe = microbesTransform.gameObject.GetComponents & lt; Microbe & gt; ();
            totalHealth += microbe != null ? microbe.Health : 0f;
        }
        string text = string.Format(&quot; Total microbes: { 0}
        Avg health { 1}
        &quot;, _microbes.Length, _microbes.Length / totalHealth);
        gameObject.transform.GetComponent & lt; Text & gt; ().text = text;
        Debug.Log(text);
    }
}
*/
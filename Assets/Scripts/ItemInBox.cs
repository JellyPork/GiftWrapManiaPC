using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInBox : MonoBehaviour
{
    [SerializeField]
    public string savedItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setData(string data)
    {
        savedItem = data;
    }

    public string getData()
    {
        return savedItem;
    }
}

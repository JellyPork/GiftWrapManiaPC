using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBox : MonoBehaviour
{
    public GameObject newBox;// nuevo objeto que tomara el lugar del otro
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        string itemToSave = gameObject.name.ToString();
     if(other.gameObject.CompareTag("Closeable"))//si el objeto con el que interactua puede ser cerrado
     {
        GameObject parentObjectOfOther = other.gameObject.transform.root.gameObject;//saca el objeto padre 
        Destroy(gameObject);
        Destroy(parentObjectOfOther);//destruye los objetos
        Instantiate(newBox,parentObjectOfOther.transform.position,parentObjectOfOther.transform.rotation);
            //crea el objeto dado en newBox en la ubicacion del objeto padre
            ClosedBoxItem newBoxScript = newBox.GetComponent<ClosedBoxItem>();
            if(newBoxScript != null)
            {
                newBoxScript.setData(itemToSave);
            }
     }
    } 
}

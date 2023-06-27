using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBox : MonoBehaviour
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
    if(other.gameObject.CompareTag("Wrapable"))//si el objeto con el que interactua puede ser envuelto
    {
        GameObject parentObjectOfOther = other.gameObject.transform.root.gameObject;//saca el objeto padre 
      
        //crea el objeto dado en newBox en la ubicacion del objeto padre
        GameObject instantiatedBox = Instantiate(newBox, parentObjectOfOther.transform.position, parentObjectOfOther.transform.rotation);
        ItemInBox newBoxItemScript = instantiatedBox.GetComponent<ItemInBox>();
        ItemInBox oldBoxItemScript = parentObjectOfOther.GetComponent<ItemInBox>();//el objeto guardado en un script

        if (newBoxItemScript != null)
        {
            newBoxItemScript.setData(oldBoxItemScript.getData()); //pasar el objeto guardado de uno al otro
        }
        Destroy(gameObject);
        Destroy(parentObjectOfOther);//destruye los objetos
    }
        
    }
}

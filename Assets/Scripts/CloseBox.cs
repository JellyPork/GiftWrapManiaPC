using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBox : MonoBehaviour
{
    public GameObject newBox;// nuevo objeto que tomara el lugar del otro
    // Start is called before the first frame update

    private string itemToSave;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        
     if(other.gameObject.CompareTag("Closeable"))//si el objeto con el que interactua puede ser cerrado
     {
        itemToSave = gameObject.name.ToString();
        GameObject parentObjectOfOther = other.gameObject.transform.root.gameObject;//saca el objeto padre 
        Destroy(gameObject);
        Destroy(parentObjectOfOther);//destruye los objetos
            GameObject instantiatedBox = Instantiate(newBox, parentObjectOfOther.transform.position, parentObjectOfOther.transform.rotation);
            ItemInBox newBoxScript = instantiatedBox.GetComponent<ItemInBox>();

            if (newBoxScript != null)
            {
                newBoxScript.setData(itemToSave);
            }


        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientRecibeAndJudge : MonoBehaviour
{
    public string myGift;
    public string myColor;
    public ClientBehavior client;
    
    // Start is called before the first frame update
    void Start()
    {
    ItemInBox myItem = gameObject.GetComponent<ItemInBox>(); //sacar el nombre del regalo que tiene
    myGift = myItem.getData();
    myColor = gameObject.tag; // sacar el tag del regalo que representa el color
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Client"))
        {
            Destroy(gameObject);
            client = other.gameObject.GetComponent<ClientBehavior>(); //sacar lo que quiere el cliente segun su script clientBehavior.
            if(client.GetDesiredGift().name == myGift && client.GetDesiredColor() == myColor) print("Gracias.");   
            else print("bato menso....");//si fue lo que queria desplegar un mensaje.
        }
    }


}

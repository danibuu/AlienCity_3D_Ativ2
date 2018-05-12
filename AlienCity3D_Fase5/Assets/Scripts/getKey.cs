using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getKey : MonoBehaviour {
    private GameObject Manager;
    private Manager GM;
    public GameObject som;
    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        GM = Manager.GetComponent<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
			//chave verde
            if (gameObject.name == "key01") 
            {
                GM.hasGreen = true;
                GM.keyverde.color = GM.fullColor;
            }
			//chave azul
            if (gameObject.name == "key02")
            {
                GM.hasBlue = true;
                GM.keyazul.color = GM.fullColor;
            }
            VarTemp.holdKeys++;
            
            Instantiate(som, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        
    }
}

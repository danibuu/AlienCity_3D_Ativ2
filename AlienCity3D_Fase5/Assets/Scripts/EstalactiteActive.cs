using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactiteActive : MonoBehaviour {

    private Rigidbody rbd;
    private Vector3 originalPosition;
    private AudioSource som;
    
	
	void Start () {
        rbd = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        
	}

    public void ativar()
    {
            rbd.isKinematic = false;
            Invoke("Resetst", 5);
    }

    void Resetst()
    {
        rbd.isKinematic = true;
        rbd.velocity = Vector3.zero;
        transform.position = originalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDamage>().takeDamage(20);
        }
    }
}

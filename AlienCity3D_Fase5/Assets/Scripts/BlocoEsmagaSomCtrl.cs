using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoEsmagaSomCtrl : MonoBehaviour {

    private AudioSource asbloco;
    public bool podeTocar = false;
	void Start () {
        asbloco = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if (podeTocar)
        {
            podeTocar = false;
            Invoke("audioPlay", 0.1f);
        }
    }

    public void audioPlay()
    {
        asbloco.PlayDelayed(0.1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            {
                other.GetComponent<PlayerDamage>().die();
            }
            
        }
    }

}

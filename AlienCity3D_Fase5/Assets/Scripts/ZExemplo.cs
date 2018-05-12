using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZExemplo : MonoBehaviour {

    //Aqui inicialmente está definido o texto
    //que você configurou pelo editor
    public Text exemploText;
	
	void Start () {
        //Para setar um novo texto
        exemploText.text = "Texto desejado.";
	}
	
	void Update () {
		
	}
}

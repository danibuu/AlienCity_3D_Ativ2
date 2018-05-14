using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase5Exit : MonoBehaviour {
	
    public GameObject manager;
    private Manager mng;

	// Use this for initialization
	void Start () {
        mng = manager.GetComponent<Manager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && mng.colectDiamondsControl0 != mng.colectDiamondsControl1)
        {
			mng.setaTexto("Só humanos podem passar! Colete os diamantes");
			Invoke("limpaTexto", 6f);
        }
        else
        {
			mng.setaTexto("Parabéns! Você voltou a ser humano!!");
            Invoke("carregaCena", 6);
        }
    }

    private void carregaCena()
    {
        SceneManager.LoadScene("Abertura");
    }

    private void limpaTexto()
    {
        mng.setaTexto("");
    }
}

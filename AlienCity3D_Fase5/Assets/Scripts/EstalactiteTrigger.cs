using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactiteTrigger : MonoBehaviour {

    private EstalactiteActive[] filhos;
    private float tempoParaAtivar;
    private bool podeAtivar = true;
    private AudioSource som;
    private ParticleSystem ptr;

    void Start()
    {
        filhos = GetComponentsInChildren<EstalactiteActive>();
        som = GetComponentInChildren<AudioSource>();
        ptr = GetComponentInChildren<ParticleSystem>();
        //Debug.Log(filhos.Length);
    }

    private void Update()
    {
        if (tempoParaAtivar < Time.time && !podeAtivar)
        {
            podeAtivar = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && podeAtivar)
        {
            podeAtivar = false;
            tempoParaAtivar = Time.time + 6.5f;
            som.Play();
            ptr.Play();
            Invoke("ativaStalactites", 1f);
        }
    }

    private void ativaStalactites()
    {
        foreach (var codigo in filhos)
        {
            codigo.ativar();
        }
    }
}

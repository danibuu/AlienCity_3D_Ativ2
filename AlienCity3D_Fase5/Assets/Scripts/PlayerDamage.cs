using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

    public GameObject malha;
    public GameObject arma;
    public Camera cmr;
    private PlayerController pc;
    private int HP = 100;
    public bool isDead = false;
    public Slider sld;
    private int vidas = 3;
    private Vector3 playerTransform;
    private Vector3 playerRotation;
    public Image[] coracoes = new Image[3];
    public Text gameOver;
    private bool isGameOver = false;
    private bool canDamage = true;
    private Animator anm;
    public GameObject dieSound;
    public GameObject hurtSound;

	// Use this for initialization
	void Start () {
        gameOver.text = "";
        playerTransform = transform.position;
        playerRotation = transform.rotation.eulerAngles;
        sld.value = HP;
        pc = GetComponent<PlayerController>();
        anm = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (HP < 0 && !isDead)
        {
            
            HP = 0;
            isDead = true;
            die();
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Jogo");
        }
	}

    public void die()
    {
        if (canDamage)
        {
            canDamage = false;
            Instantiate(dieSound, transform.position, Quaternion.identity);
            pc.enabled = false;
            anm.SetTrigger("Morre");
            sld.value = 0;
            Invoke("desativaMalha", 1.5f);
            if (vidas > 0)
            {
                Invoke("revive", 2);
            }
            else
            {
				gameOver.text = "Fim de jogo!!\n!\nPressione 'R' para reiniciar.";
                isGameOver = true;
            }
        }
        
    }

    public void takeDamage(int hp)
    {
        if(HP>=0 && !isDead)
        {
            HP -= hp;
            sld.value = HP;
            Instantiate(hurtSound, transform.position, Quaternion.identity);
        }
    }
    private void desativaMalha()
    {
        malha.SetActive(false);
        arma.SetActive(false);        
    }

    private void revive()
    {
        
        transform.position = playerTransform;
        transform.rotation = Quaternion.Euler(playerRotation);
        pc.enabled = true;
        anm.SetTrigger("Parado");
        malha.SetActive(true);
        arma.SetActive(true);
        vidas--;
        HP = 100;
        sld.value = HP;
        isDead = false;
        canDamage = true;

        switch (vidas)
        {
            
            case 2:
                coracoes[2].color = new Vector4(255, 255, 255, 0);
                break;
            case 1:
                coracoes[1].color = new Vector4(255, 255, 255, 0);
                break;
            case 0:
                coracoes[0].color = new Vector4(255, 255, 255, 0);
                break;
        }
        
    }
}

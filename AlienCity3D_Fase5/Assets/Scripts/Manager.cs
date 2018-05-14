using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	
    private GameObject[] key;
    public Animator porta;
    public bool hasBlue = false;
    public bool hasGreen = false;
    public bool canDoAction = false;
    public GameObject keylogger;
    private insertKeys inserirChaves;
    public Image keyverde;
    public Image keyazul;

    public Vector4 fullColor = new Vector4(255f, 255f, 255f, 255f);
    public Vector4 halfColor;
    private GameObject[] Diamonds;
    private int colectedDiamonds = 0;
    public Text status;
    public Text diamondsCount;
    public Text exitText;
    public int colectDiamondsControl1 = 0;
    public int colectDiamondsControl0 = 0;

    public GameObject som;
    public GameObject som2;


	public GameObject HudAlienCicy;

    // Use this for initialization
    void Start () {
        Diamonds = GameObject.FindGameObjectsWithTag("pedra");
        colectDiamondsControl0 = Diamonds.Length;
        halfColor = keyverde.color;
        key = GameObject.FindGameObjectsWithTag("key");
        
		HudAlienCicy.SetActive(false);
        
	}

    
	
	// Update is called once per frame
	void Update () {
        inserirChaves = keylogger.GetComponent<insertKeys>();

		//Pressine a tecla G para abrir  porta
		if (Input.GetKeyDown(KeyCode.G))
        {
            if (canDoAction)
            {
                DoAction();
            }
        }
    }

    void DoorOpen()
    {
        keylogger.GetComponent<Collider>().enabled = false;
        porta.SetTrigger("open");
    }

    void DoAction()
    {
		//Ativa a imagem da chave azul.
		//
		if (hasBlue)
		{
			inserirChaves.blueKeyInsert.SetActive(true);
			keyazul.color = halfColor;
			hasBlue = false;
			Instantiate(som, transform.position, Quaternion.identity);

		}



		//Ativa a imagem da chave verde.
        if (hasGreen)
        {
            inserirChaves.greenKeyInsert.SetActive(true);
            keyverde.color = halfColor;
            hasGreen = false;
            Instantiate(som, transform.position, Quaternion.identity);
            
        }

        //VAi abrir a porta caso possua as 2 chaves.
        if (VarTemp.holdKeys == key.Length)
        {
            VarTemp.holdKeys = 0;
            DoorOpen();
            Instantiate(som, transform.position, Quaternion.identity);
            Instantiate(som2, transform.position, Quaternion.identity);
        }
    }

    public void testDiamond(int dia)
    {
        colectedDiamonds += dia;
        colectDiamondsControl1 = colectedDiamonds;
        diamondsCount.text = (colectedDiamonds + "/20");
        if(colectedDiamonds == Diamonds.Length)
        {
            status.text = "Status: Humano";
        }
    }

    public void setaTexto(string texto)
    {
        exitText.text = texto;
    }
}

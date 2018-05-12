using UnityEngine;
using System.Collections;

public class RotacionaPedra : MonoBehaviour {
    private GameObject Manager;
    private Manager mng;
    public GameObject som;
    

    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        mng = Manager.GetComponent<Manager>();
        
    }
    void Update () {
		transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Player"))
			{
            mng.testDiamond(1);
            Instantiate(som, transform.position, Quaternion.identity);
			Destroy(gameObject);
			}
	}
}

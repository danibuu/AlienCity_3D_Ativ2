using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
    public float MoveSpeedX;
	public float RotationSpeed;

	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;
    public GameObject jumpSound;
  
    void Start()
	{
        cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    }



	void Update()
	{
		Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
        Vector3 moveX = Input.GetAxis("Horizontal") * transform.TransformDirection(Vector3.right) * MoveSpeedX;

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime, 0));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
                Instantiate(jumpSound, transform.position, Quaternion.identity);
				gravidade.y = 6f;
				jump = false;
			}
		}
		move += gravidade;
        moveX += gravidade;
		cc.Move (move* Time.deltaTime);
        cc.Move(moveX * Time.deltaTime);
        Anima ();
	}
	 
	void Anima()
	{
		if (!Input.anyKey)
		{
			anim.SetTrigger("Parado");
		} 
		else 
		{
			if(Input.GetKeyDown("space"))
			{
				anim.SetTrigger("Pula");
				jump = true;
			}
			else
			{
                    anim.SetTrigger("Corre");
			}
		}
	}
}

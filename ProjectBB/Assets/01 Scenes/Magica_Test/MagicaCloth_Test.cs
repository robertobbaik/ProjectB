#if !OUT_GAME_ONLY
using F4.Manager;
using F4.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialController : MonoBehaviour
{
	public FaceController faceController;

	private void Awake()
    {
		faceController = gameObject.GetComponent<FaceController>();

	}
	protected void OnAnimEvent(string eventKey)
	{
		

		switch (eventKey)
		{
			case "step_l":
				{
				}
				break;
			case "step_r":
				{
				}
				break;
			case "eyeclose":
			case "angry":
			case "fury":
			case "surprise":
			case "pain":
			case "smile":
				var controller = faceController;
				if (controller)
				{
					controller.Play(eventKey);
				}
				break;

		}
	}
	protected void FaceEvent(string eventKey)
	{


		switch (eventKey)
		{
			case "step_l":
				{
				}
				break;
			case "step_r":
				{
				}
				break;
			case "eyeclose":
			case "angry":
			case "fury":
			case "surprise":
			case "pain":
			case "smile":
				var controller = faceController;
				if (controller)
				{
					controller.Play(eventKey);
				}
				break;

		}
	}
}

public class MagicaCloth_Test : MonoBehaviour
{
	Animator m_Animator;
	//public float speed = 1f;

	public float spinSpeed = 100f; // rotate speed
	public RuntimeAnimatorController animcontroller;// animator add
	public Object animdata;//= new AnimatorOverrideController(animcontroller);

	//object

	GameObject[] objt;
	ManagerCharacter managerChar;
	//Forward Direction
	//bool ForwardY = true;


	void _All() //animator motion call
	{

		for (int i = 0; i < objt.Length; i++)
		{
			//objt[i].transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self); //rotate object
			if (objt[i].transform.parent == null)
				m_Animator = objt[i].GetComponent<Animator>();// object to ani

		}

	}


	void _reset() // position reset
	{
		for (int i = 0; i < objt.Length; i++)
		{
			objt[i].transform.position = new Vector3(0, 0, 0); // reset position
			objt[i].transform.rotation = Quaternion.Euler(0, 0, 0); // reset rotation
		}
	}


	void _Ani() // animator add
	{

		for (int i = 0; i < objt.Length; i++)
		{
			Animator animator = objt[i].gameObject.GetComponent<Animator>();
			var animatorOverrideController = new AnimatorOverrideController(animcontroller);
			AnimationClip[] anims = Resources.LoadAll<AnimationClip>("MyModel");

			animatorOverrideController.name = objt[i].gameObject.name + "_OvrAnimController";
			//         for (int j = 0; j < animatorOverrideController.runtimeAnimatorController.animationClips.Length; j++)
			//         {
			//	Instantiate(animdata).name = "TEE";
			//	//animdata.GetComponent<Animation>
			//	//animatorOverrideController.runtimeAnimatorController.animationClips[j] = 

			//}
			animator.runtimeAnimatorController = animatorOverrideController;
			//animator.gameObject.AddComponent<FacialController>();
			if (animator.gameObject.GetComponent<PlayerController>() == null)
				animator.gameObject.AddComponent<PlayerController>();
			managerChar.SetCharacterFaceAnimation(animator.gameObject);
		}

	}

	private void Awake()
	{
		managerChar = FindObjectOfType<ManagerCharacter>();

		var objanimator = FindObjectsOfType<Animator>();// ("MagicaTest");
		objt = new GameObject[objanimator.Length];
		for (int i = 0; i < objanimator.Length; i++)
		{
			objt[i] = objanimator[i].gameObject;
		}
	}

	void Start()
	{
		//Tag serch


		_All();

		_Ani();

	}

	void Update()
	{



		if (Input.GetKey(KeyCode.LeftArrow) == true)
		{

			objt = GameObject.FindGameObjectsWithTag("MagicaTest");
			foreach (GameObject o in objt)
				o.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.RightArrow) == true)
		{

			objt = GameObject.FindGameObjectsWithTag("MagicaTest");
			foreach (GameObject o in objt)
				o.transform.Rotate(-Vector3.up * spinSpeed * Time.deltaTime);
		}


		if (Input.GetKey(KeyCode.KeypadEnter))
		{
			_reset();
		}


		//Press the up arrow button to reset the trigger and set another one
		if (Input.GetKey(KeyCode.Keypad0) || Input.GetKey(KeyCode.Alpha0))
		{
			//Send the message to the Animator to activate the trigger parameter named "Jump"
			m_Animator.SetTrigger("00");
		}

		if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("01");
		}

		if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("02");
		}

		if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("03");
		}

		if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("04");
		}

		if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.Alpha5))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("05");
		}

		if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Alpha6))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("06");
		}

		if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.Alpha7))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("07");
		}

		if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.Alpha8))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("08");
		}

		if (Input.GetKey(KeyCode.Keypad9) || Input.GetKey(KeyCode.Alpha9))
		{
			//Send the message to the Animator to activate the trigger parameter named "Crouch"
			m_Animator.SetTrigger("09");
		}

		if (Input.GetKey(KeyCode.PageUp))
		{
			float time = Mathf.Min(Time.timeScale + 0.05f, 2);
			Time.timeScale = time;
		}

		if (Input.GetKey(KeyCode.PageDown))
		{
			float time = Mathf.Max(Time.timeScale - 0.05f, 0.0f);
			Time.timeScale = time;
		}

		if (Input.GetKey(KeyCode.Home))
		{
			Time.timeScale = 1;
		}
		}
	}
#endif

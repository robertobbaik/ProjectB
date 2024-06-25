using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveR : MonoBehaviour
{
	//
	// VARIABLES
	//
	
	public float turnSpeed = 2.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 0.15f;		// Speed of the camera when being panned

	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isRotating;	// Is the camera being rotated?

	
	
	public float m_zoomSpeed = 4f;
	public float m_zoomMax = 0f;
	public float m_zoomMin = 15f;
	
	
	//CameraZoom
	void CameraZoom()
	{
		float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");
		
		if(transform.position.y <= m_zoomMax && t_zoomDirection>0)
			return;
			
		if(transform.position.y >= m_zoomMin && t_zoomDirection<0)
			return;
			
		transform.position += transform.forward*t_zoomDirection*m_zoomSpeed;
		
	}
	
	
	void CamreaZ()
	{
		transform.position = new Vector3(-0.07f,1.57f,3.32f);
		transform.rotation = Quaternion.Euler (new Vector3(6.53f,179.45f,0f));
		
	}
	
	void CamreaX()
	{
		transform.position = new Vector3(-4.16f,1.38f,0.08f);
		transform.rotation = Quaternion.Euler (new Vector3(6.53f,95.55f,0f));
		
	}
	
	void CamreaC()
	{
		transform.position = new Vector3(-0.56f,1.76f,-2.86f);
		transform.rotation = Quaternion.Euler (new Vector3(11.51f,17.33f,0f));
		
	}
	
	void CamreaV()
	{
		transform.position = new Vector3(4.15f,1.76f,0.72f);
		transform.rotation = Quaternion.Euler (new Vector3(6.53f,263.54f,0f));
		
	}
	
	
	//
	// UPDATE
	//
	

	
	void Update () 
	{
		
		CameraZoom();

		// 카메라 위치
		if (Input.GetKey(KeyCode.Z))
		{
			CamreaZ();
		}
		if (Input.GetKey(KeyCode.X))
		{
			CamreaX();
		}
		if (Input.GetKey(KeyCode.C))
		{
			CamreaC();
		}
		if (Input.GetKey(KeyCode.V))
		{
			CamreaV();
		}



		// Get the left mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}
		

		// Disable movements on button release
		if (!Input.GetMouseButton(1)) isRotating=false;
		if (!Input.GetMouseButton(2)) isPanning=false;

		
		// Rotate camera along X and Y axis
		if (isRotating)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}
		
		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = new Vector3(-pos.x * panSpeed, -pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}
		

	}
}




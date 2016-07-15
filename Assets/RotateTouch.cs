using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Class that takes touch input and uses it to rotate and scale objects and activate a script.
/// </summary>
public class RotateTouch : MonoBehaviour 
{
	#if UNITY_ANDROID || UNITY_IOS

	float moveSpeed;

	void Start()
	{
		moveSpeed = 5f;
	}
		
	void Update()
	{
		processDrag ();
	}

	/// <summary>
	/// Checks for drag controls.
	/// </summary>
	void processDrag()
	{
		if (Input.touchCount == 1) 
		{
			//Store input
			Touch fing = Input.GetTouch (0);

			if(fing.phase == TouchPhase.Moved)	//If the finger has moved since the last frame
			{
				//Find the amount the finger has moved, and apply a rotation to this gameobject based on that amount
				Vector3 rotation = transform.localRotation.eulerAngles;
				Vector2 fingMove = fing.deltaPosition;
				float deltaY = fingMove.x * moveSpeed * Time.deltaTime;

				rotation.y -= deltaY;

				this.transform.localRotation = Quaternion.Euler (rotation);
			}
		}
	}
	#endif
}
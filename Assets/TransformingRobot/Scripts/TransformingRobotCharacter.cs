using UnityEngine;
using System.Collections;

public class TransformingRobotCharacter : MonoBehaviour 
{
	public Animator robotAnimator;
	public float robotSpeed=1f;
	public float tankSpeed=1f;
	public float tankRotateSpeed=1f;

	public float planeSpeed=1f;
	public float planeRotateSpeed=1f;

	public int robotMode=1; // 0:robot, 1:tank, 2:plane
	Rigidbody robotRigidBody;

	public GameObject bone002;

	float timer = 0f;
	int modeSelect = 0;
	int prevSelect = 0;
	bool goingUp = true;

	// Use this for initialization
	void Start () 
	{
		robotAnimator = GetComponent<Animator> ();
		robotAnimator.speed = robotSpeed;
		robotRigidBody = GetComponent<Rigidbody> ();
		timer = 10f;
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			timer = 5f;

			while (modeSelect == prevSelect) 
			{
				modeSelect = Random.Range (0, 3);
			}

			if (modeSelect == 0) 
			{
				Robot ();
			}

			else if(modeSelect == 1)
			{
				Tank ();
			}

			else if(modeSelect == 2)
			{
				Plane();
				transform.localPosition = new Vector3 (0, 60, 0);
			}

			prevSelect = modeSelect;
		}

		if (modeSelect == 2) 
		{
			if (transform.localPosition.y < 40)
			{
				goingUp = true;
			}
			if (transform.localPosition.y > 80) 
			{
				goingUp = false;
			}
			if (goingUp) 
			{
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + 1f, transform.localPosition.z);
			}
			else
			{
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - 1f, transform.localPosition.z);
			}
		}

		else
		{
			transform.localPosition = new Vector3 (0, 0, 0);
			transform.localRotation.eulerAngles.Set(0, transform.localRotation.eulerAngles.y, 0);
		}
			
	}

	public void RobotModeChange(int aRobotMode)
	{
		robotMode = aRobotMode;

		if (robotMode == 0) 
		{
			robotAnimator.applyRootMotion=true;
		} 

		else if (robotMode == 1) 
		{
			robotAnimator.applyRootMotion=false;
		}

		else if(robotMode==2)
		{
			robotAnimator.applyRootMotion=false;
		}

	}


	public void Robot()
	{
		RobotModeChange (0);
		robotAnimator.SetTrigger ("Robot");
	}

	public void Tank()
	{
		RobotModeChange (1);
		robotAnimator.SetTrigger ("Tank");

	}

	public void Plane()
	{
		RobotModeChange (2);
		robotAnimator.SetTrigger ("Plane");

	}
}

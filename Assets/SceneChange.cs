using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChange : MonoBehaviour 
{
	public void butterflyScene()
	{
		SceneManager.LoadScene ("Animation_Butterfly");
	}

	public void robotScene()
	{
		SceneManager.LoadScene ("Animation_Robot");
	}

	public void cactusScene()
	{
		SceneManager.LoadScene ("Animation_Cactus");
	}

	public void menuScene()
	{
		SceneManager.LoadScene ("Animation_Menu");
	}
}
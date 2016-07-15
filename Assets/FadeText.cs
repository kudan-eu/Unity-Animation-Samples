using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour 
{
	public Text text;

	float timer;

	void Start () 
	{
		timer = 3f;
	}

	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0f) 
		{
			Color tempPanelColor = GetComponent<Image>().color;
			Color tempTextColor = text.color;

			tempPanelColor.a -= 0.5f * Time.deltaTime;
			tempTextColor.a -= 0.5f * Time.deltaTime;

			GetComponent<Image> ().color = tempPanelColor;
			text.color = tempTextColor;
		}
	}
}

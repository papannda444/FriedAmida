using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLine : MonoBehaviour
{
	[SerializeField] GameObject OnObj;
	[SerializeField] GameObject OffObj;
	float time = 0;
	bool foodStay = false;

	void Update()
	{
		if (OnObj.activeSelf)
		{
			time += Time.deltaTime;
			if (time > 10 && !foodStay)
			{
				time = 0;
				OnObj.SetActive(false);
			}
		}
	}

	public void OnObjActivation()
	{
		OnObj.SetActive(true);
	}

	public bool IsOnObjActive()
	{
		return OnObj.activeSelf;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "food")
		{
			foodStay = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "food")
		{
			foodStay = false;
		}
	}
}

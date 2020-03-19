using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	int xDirction = 0;
	float speed = 0.02f;

	public int XDirection
	{
		set
		{
			if (value <= -1)
			{
				xDirction = -1;
			}
			else if (value >= 1)
			{
				xDirction = 1;
			}
			else
			{
				xDirction = 0;
			}
		}

		get
		{
			return xDirction;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (xDirction == 0)
		{
			transform.Translate(0, -1 * speed, 0);
		}
		else
		{
			transform.Translate(xDirction * speed, 0, 0);
		}
    }

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "right")
		{
			transform.position = col.gameObject.transform.position;
			ChangeDirection(-1);
		}
		else if (col.gameObject.tag == "left")
		{
			transform.position = col.gameObject.transform.position;
			ChangeDirection(1);
		}

		if (col.gameObject.tag == "box")
		{
			Destroy(gameObject);
		}
	}

	void ChangeDirection(int x)
	{
		if (XDirection == 0)
		{
			XDirection = x;
		}
		else
		{
			XDirection = 0;
		}
	}
}

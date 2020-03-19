using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCursol : MonoBehaviour
{
	[System.SerializableAttribute]
	public class HLineList
	{
		public List<GameObject> YHLines;
	}

	[SerializeField] List<HLineList> XHLines;
	int nowX = 0;
	int nowY = 0;

	public int NowX
	{
		set
		{
			if (value < 0)
			{
				nowX = 0;
			}
			else if (value >= XHLines.Count-1)
			{
				nowX = XHLines.Count - 1;
			}
			else
			{
				nowX = value;
			}
		}

		get
		{
			return nowX;
		}
	}

	public int NowY
	{
		set
		{
			if (value < 0)
			{
				nowY = 0;
			}
			else if (value >= XHLines[NowX].YHLines.Count - 1)
			{
				nowY = XHLines[NowX].YHLines.Count - 1;
			}
			else
			{
				nowY = value;
			}
		}

		get
		{
			return nowY;
		}
	}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.position = XHLines[NowX].YHLines[NowY].transform.position;

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			NowY--;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			NowY++;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			NowX++;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			NowX--;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			DrawHLine();
		}
	}

	void DrawHLine()
	{
		//配列外を参照しないためにNowXを条件にしている
		if (NowX < XHLines.Count - 1 && XHLines[NowX + 1].YHLines[NowY].GetComponent<HorizontalLine>().IsOnObjActive())
		{
			return;
		}

		if (NowX > 0 && XHLines[NowX - 1].YHLines[NowY].GetComponent<HorizontalLine>().IsOnObjActive())
		{
			return;
		}

		XHLines[NowX].YHLines[NowY].GetComponent<HorizontalLine>().OnObjActivation();
	}
}

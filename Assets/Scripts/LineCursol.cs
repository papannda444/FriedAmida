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

	enum Direction
	{
		Up = 1,
		Down = 2,
		Right = 3,
		Left = 4
	}

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
			MoveCursol(Direction.Up);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			MoveCursol(Direction.Down);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveCursol(Direction.Right);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveCursol(Direction.Left);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			DrawHLine();
		}
	}

	void DrawHLine()
	{
		XHLines[NowX].YHLines[NowY].GetComponent<HorizontalLine>().OnObjActivation();
	}

	void MoveCursol(Direction dir)
	{
		switch (dir)
		{
			case Direction.Up:
				NowY--;
				break;
			case Direction.Down:
				NowY++;
				break;
			case Direction.Right:
				NowX++;
				break;
			case Direction.Left:
				NowX--;
				break;
		}
	}
}

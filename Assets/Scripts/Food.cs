using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	enum OilTemp
	{
		high,
		moderate,
		low
	}

	int xDirction = 0;
	float speed = 0.02f;
	[SerializeField] int clearKomugiko;
	[SerializeField] int clearEgg;
	[SerializeField] int clearPanko;
	[SerializeField] int calorie;
	[SerializeField] OilTemp oilTemp;
	int nowKomugiko = 0;
	int nowEgg = 0;
	int nowPanko = 0;
	int nowBadItem = 0;

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
		string tag = col.gameObject.tag;

		switch (tag)
		{
			//あみだの横線
			case "right":
				transform.position = col.gameObject.transform.position;
				ChangeDirection(-1);
				break;
			case "left":
				transform.position = col.gameObject.transform.position;
				ChangeDirection(1);
				break;

			//油
			case "box":
				Destroy(gameObject);
				break;
			case "lowOil":
				DoFry(OilTemp.low);
				break;
			case "highOil":
				DoFry(OilTemp.high);
				break;

			//アイテム（パン粉等）
			case "egg":
				nowEgg++;
				break;
			case "komugiko":
				nowKomugiko++;
				break;
			case "panko":
				nowPanko++;
				break;
			case "badItem":
				nowBadItem++;
				break;
		}
	}

	void ChangeDirection(int x)
	{
		XDirection = XDirection != 0 ? 0 : x;
	}

	void DoFry(OilTemp oil)
	{
		//マイナスアイテムを取得していれば腐り状態
		if (nowBadItem >= 1)
		{
			Debug.Log("bad");
		}
		else
		{
			//油の温度が適正、材料全てがノルマ以上取得していれば揚げ成功
			if (oil == oilTemp && nowEgg >= clearEgg && nowKomugiko >= clearKomugiko && nowPanko >= clearPanko)
			{
				Debug.Log("good");
			}
			//材料を全く取得していなければ素揚げ、生？
			else if (nowEgg == 0 && nowKomugiko == 0 && nowPanko == 0)
			{
				Debug.Log("row");
			}
			//それ以外なら揚げ失敗
			else
			{
				Debug.Log("usually");
			}
		}

		Destroy(gameObject);
	}
}

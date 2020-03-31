using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
	//▼生成するアイテム
	[SerializeField] GameObject egg;
	[SerializeField] GameObject komugiko;
	[SerializeField] GameObject panko;
	[SerializeField] GameObject badItem;

	[SerializeField] GameObject[] generatePlaces;//アイテム生成場所
	GameObject[] generateBoxes;//アイテムデータの格納場所
	[SerializeField] float geneateSpan = 3;

    // Start is called before the first frame update
    void Start()
    {
		generateBoxes = new GameObject[generatePlaces.Length];
		InvokeRepeating("FoodGenerate", 0, geneateSpan);
	}

    // Update is called once per frame
    void Update()
    {

    }

	void FoodGenerate()
	{
		//▼生成アイテムの決定
		int rand = Random.Range(0, 100);
		Debug.Log(rand);
		GameObject createObj;
		if (rand < 10)
		{
			createObj = badItem;
		}
		else if (rand < 40)
		{
			createObj = egg;
		}
		else if (rand < 70)
		{
			createObj = komugiko;
		}
		else
		{
			createObj = panko;
		}

		//▼生成場所の決定
		List<int> emptyDates = new List<int>();

		int i = 0;
		foreach(GameObject generateBox in generateBoxes)
		{
			if (generateBox == null)
			{
				emptyDates.Add(i);
			}
			i++;
		}

		if (emptyDates.Count != 0)
		{
			rand = Random.Range(0, emptyDates.Count);
			int generateNum = emptyDates[rand];

		//▼生成
			generateBoxes[generateNum] = Instantiate(createObj, generatePlaces[generateNum].transform.position, Quaternion.identity);
		}
	}
}

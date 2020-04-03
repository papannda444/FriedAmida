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
	}

    // Update is called once per frame
    void Update()
    {

    }

	public void AllItemGenerate(int eggNum, int komugikoNum, int pankoNum, int badItemNum)
	{
		FoodGenerate(egg, eggNum);
		FoodGenerate(komugiko, komugikoNum);
		FoodGenerate(panko, pankoNum);
		FoodGenerate(badItem, badItemNum);
	}

	void FoodGenerate(GameObject createObj, int createNum)
	{
		for (int j = 0; j < createNum; j++)
		{
			//▼生成場所の決定
			List<int> emptyDates = new List<int>();

			int i = 0;
			foreach (GameObject generateBox in generateBoxes)
			{
				if (generateBox == null)
				{
					emptyDates.Add(i);
				}
				i++;
			}

			if (emptyDates.Count != 0)
			{
				int rand = Random.Range(0, emptyDates.Count);
				int generateNum = emptyDates[rand];

				//▼生成
				generateBoxes[generateNum] = Instantiate(createObj, generatePlaces[generateNum].transform.position, Quaternion.identity);
			}
		}
	}
}

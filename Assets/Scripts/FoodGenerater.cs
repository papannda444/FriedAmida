using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerater : MonoBehaviour
{
	[SerializeField] GameObject[] foods;
	[SerializeField] GameObject[] generatePlaces;
	float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;

		if (time > 3)
		{
			FoodGenerate();

			time = 0;
		}
    }

	void FoodGenerate()
	{
		GameObject item;
		GameObject place;

		//▼生成アイテムの決定
		int rand = Random.Range(0, foods.Length);
		item = foods[rand];

		//▼生成位置の決定
		rand = Random.Range(0, generatePlaces.Length);
		place = generatePlaces[rand];

		//▼生成
		Instantiate(item, place.transform.position, Quaternion.identity);
	}
}

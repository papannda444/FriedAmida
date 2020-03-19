using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerater : MonoBehaviour
{
	[SerializeField] GameObject food;
	[SerializeField] GameObject[] generateBox;
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
		int rand = Random.Range(0, generateBox.Length);
		Instantiate(food, generateBox[rand].transform.position, Quaternion.identity);
	}
}

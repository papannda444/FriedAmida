﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amida;

public class Oil : MonoBehaviour
{
	public Cooking.OilTemp oilTemp;

	public delegate void CompletedFriedFoodDelegate(FriedFood friedFood);
	public CompletedFriedFoodDelegate completedFriedFoodDelegate;

    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void DoTargetAmime(bool isTarget)
	{
		GetComponent<Animator>().SetBool("target", isTarget);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "food")
		{
			Food food;
			food = collision.gameObject.GetComponent<Food>();
			FriedFood friedFood;
			friedFood = food.DoFry(oilTemp);
			completedFriedFoodDelegate(friedFood);
			Destroy(collision.gameObject);
		}
	}
}

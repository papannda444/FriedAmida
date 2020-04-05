using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amida;

public class FriedFood
{
	public Cooking.Status FryStatus { get; private set; }
	public int Calorie { get; private set; }

	public FriedFood(Cooking.Status status, int calorie)
	{
		this.FryStatus = status;
		this.Calorie = calorie;
	}
}

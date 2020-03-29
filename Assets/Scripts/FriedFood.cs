using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriedFood : MonoBehaviour
{
	public enum Status
	{
		good,
		usually,
		raw,
		bad
	}

	Status status;
	int calorie;

	public FriedFood(Status status, int calorie)
	{
		this.status = status;
		this.calorie = calorie;
	}
}

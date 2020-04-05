using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject stageManager;
	StageManager st;
	[SerializeField] GameObject foodGenerater;
	FoodGenerater fg;
	[SerializeField] GameObject[] oilObjs;

	GameObject presentEnemyObj;//現在戦闘中の敵
	Customer presentCustomer;//●変数名微妙●

	//●Playerクラスに分ける可能性あり●
	int rushGage;
	int score;

	// Start is called before the first frame update
	void Start()
	{
		st = stageManager.GetComponent<StageManager>();
		fg = foodGenerater.GetComponent<FoodGenerater>();

		//１：次の戦闘準備
		presentEnemyObj = st.NextBattleStart();
		presentCustomer = presentEnemyObj.GetComponent<Customer>();

		presentCustomer.killedCustomerDelegate = KilledCustomer;
		foreach (GameObject oilObj in oilObjs)
		{
			oilObj.GetComponent<Oil>().completedFriedFoodDelegate = CompleteFriedFood;
		}

		//2：敵に応じた食材生成
		fg.FoodsGenerate(presentCustomer.SynchroFoodNum);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void GameStart()
	{

	}

	void KilledCustomer()
	{
		Destroy(presentEnemyObj);

		if (st.IsLastEnemy())
		{
			ClearGame();
			return;
		}

		presentEnemyObj = st.NextBattleStart();
		presentCustomer = presentEnemyObj.GetComponent<Customer>();

		presentCustomer.killedCustomerDelegate = KilledCustomer;

	}

	void CompleteFriedFood(FriedFood friedFood)
	{
		//4：揚げ物を敵に渡す
		//5：敵による揚げ物評価(スコア処理未実装）
		presentCustomer.DoReaction(friedFood);

		//2：敵に応じた食材生成
		fg.FoodsGenerate(presentCustomer.SynchroFoodNum);
	}

	void ClearGame()
	{
		//８：スコア表示等

		//9：次のステージへ
		Debug.Log("clear");
	}
}

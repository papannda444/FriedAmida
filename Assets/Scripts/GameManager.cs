using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	/* 
	 　「すごくいやらしいコードだな、この変態！」
	   「ダ、ダメ、見ないで！」
	   「こんなに（処理）をグチャグチャにして、そんなにこれ（バグ）が欲しいのか？」
	   「ヤダ！漏れちゃう、（処理が）漏れちゃう！」
	*/
	[SerializeField] GameObject stageManager;
	StageManager st;
	[SerializeField] GameObject foodGenerater;
	FoodGenerater fg;

	GameObject presentEnemyObj;//現在戦闘中の敵
	Customer presentCustomer;//●変数名微妙●
	public FriedFood MadeFriedFood;

	//●Playerクラスに分ける可能性あり●
	int rushGage;
	int score;

    // Start is called before the first frame update
    void Start()
    {
		st = stageManager.GetComponent<StageManager>();
		fg = foodGenerater.GetComponent<FoodGenerater>();
		Invoke("GameStart", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void GameStart()
	{
		StartCoroutine(gameStart());
	}

	IEnumerator gameStart()
	{
		//敵が全員倒されるまでループ
		while (true)
		{
			//１：次の戦闘準備
			presentEnemyObj = st.NextBattleStart();
			presentCustomer = presentEnemyObj.GetComponent<Customer>();

			//敵が倒されるまでループ
			while (true)
			{
				MadeFriedFood = null;

				//2：敵に応じた食材生成
				fg.FoodsGenerate(presentCustomer.SynchroFoodNum);

				//3：揚げ物を受け取るまでループ
				while (MadeFriedFood == null)
				{
					yield return null;
				}

				//4：揚げ物を敵に渡す
				//5：敵による揚げ物評価(スコア処理未実装）
				presentCustomer.DoReaction(MadeFriedFood);

				//6：敵が倒れればループを抜ける
				if (presentCustomer.IsClear)
				{
					break;
				}
			}

			//７：現在の敵が最後の敵であればループを抜ける
			if (st.IsLastEnemy())
			{
				break;
			}
		}

		//８：スコア表示等

		//9：次のステージへ
		Debug.Log("clear");
	}
}

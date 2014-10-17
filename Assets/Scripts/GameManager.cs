using UnityEngine;
using System.Collections;
using System.Threading;
using Model;

public class GameManager : MonoBehaviour {
	int time=0;
	Charactor player;
	Charactor AI;
	string message="";
	bool die=false;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharators>().charactor;
		AI=GameObject.FindGameObjectWithTag("AI").GetComponent<AICharactors>().charactor;

		//player.TargetList.Add(AI);

		//AI.TargetList.Add(player);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.HP > 0 && AI.HP > 0) {
			Show(player.Attack(time), "A", "B", AI.HP);
			Show(AI.Attack(time), "B", "A", player.HP);
			Thread currentThread = Thread.CurrentThread;//得到当前线程
			Thread.Sleep(100);
			time += 100;
		}
		if(die==false)
		{
			if (player.HP <= 0) {player.HP=0;write("a被打死了。");die=true;}
			if (AI.HP <= 0) {AI.HP=0;write("b被打死了。");die=true;}
		}

	}
	public void Show(AttackResult result, string aName, string bName, int HP) {
		if (result != null) {
			switch (result.AttackResultType) {
			case AttackResultType.命中:
				write(aName + " 正常命中 " + bName + ",");
				break;
			case AttackResultType.暴击:
				write(aName + " 攻击 " + bName + "，暴击了！");
				break;
			case AttackResultType.闪避:
				write(aName + " 攻击 " + bName + "被闪避,");
				break;
			default:
				break;
			}
			//血量少于0就显示0
			if(HP<0)
				HP=0;
			write("造成" + result.AttackResultDamage + "点伤害，还剩" + HP.ToString() + "血量");
		}

}
	public void write(string addMessage)
	{
		if(message!="")
			message+="\n";
		message+=addMessage;
	}
	void OnGUI()
	{
		GUI.contentColor=Color.red;
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),message);
	}
}

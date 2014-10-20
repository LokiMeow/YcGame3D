using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Model;

public class GameManager : MonoBehaviour {
	int time=0;
	Charactor player;
	Charactor AI;
	string message="";
	bool die=false;
	List<Charactor> charactorList = new List<Charactor>();
	int count=0;
	
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharators>().charactor;
		AI=GameObject.FindGameObjectWithTag("AI").GetComponent<AICharactors>().charactor;

		//player.TargetList.Add(AI);

		//AI.TargetList.Add(player);
		
		charactorList.Add(player);
		charactorList.Add(AI);
		count =charactorList.Count;
	}
	
	// Update is called once per frame
	void Update () {
		if (count > 0) {
			foreach (var item in charactorList) {
			//没死和有攻击目标才能攻击
			if(item.HP>0&&item.TargetList.Count>0){
				Show(item,item.Attack(time), item.Name, charactorList);
				if (item.HP <= 0 && item.Speed != int.MaxValue) {
					item.Speed = int.MaxValue;
					count--;
				}}
			}
			Thread currentThread = Thread.CurrentThread;//得到当前线程
			Thread.Sleep(100);
			time += 100;
	
	
//		if (player.HP > 0 && AI.HP > 0) {
//			Show(player.Attack(time), "A", "B", AI.HP);
//			Show(AI.Attack(time), "B", "A", player.HP);
//			Thread currentThread = Thread.CurrentThread;//得到当前线程
//			Thread.Sleep(100);
//			time += 100;
//		}
//		if(die==false)
//		{
//			if (player.HP <= 0) {player.HP=0;write("a被打死了。");die=true;}
//			if (AI.HP <= 0) {AI.HP=0;write("b被打死了。");die=true;}
//		}
	}}
	
	//加了攻击方
	public void Show(Charactor attacker,List<AttackResult> result, string aName, List<Charactor> charactorList) {
		if (result != null) {
			foreach (var item in result) {
				var charactorTemp = (from a in charactorList
				                     where a.ID == item.UserID
				                     select a).FirstOrDefault();
				switch (item.AttackResultType) {
				case AttackResultType.命中:
					write(aName + " 正常命中 " + charactorTemp.Name + ",");
					break;
				case AttackResultType.暴击:
					write(aName + " 攻击 " + charactorTemp.Name + "，暴击了！");
					break;
				case AttackResultType.闪避:
					write(aName + " 攻击 " + charactorTemp.Name + "被闪避,");
					break;
				default:
					break;
				}
				//HP小于0就等于0
				if(charactorTemp.HP<=0)
					charactorTemp.HP=0;
				write("造成" + item.AttackResultDamage + "点伤害，还剩" + charactorTemp.HP.ToString() + "血量");
				if (charactorTemp.HP <= 0) {
					write(charactorTemp.Name + "被打死了。");
					//打死之后从目标列表中移除
					attacker.TargetList.Remove(charactorTemp);
				}
			}
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

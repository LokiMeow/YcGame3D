using UnityEngine;
using System.Collections;
using Model;
//using Service;

public class AICharactors : Charactors {
public override void Init()
{

		charactor.Name="AI";
		charactor.HP = 100;

		weapon.AttackType = AttackType.远程;
		weapon.DamageType = DamageType.魔法;
		weapon.MagicDmg = 20;
		weapon.Speed = 2000;
		charactor.Weapon = weapon;

		medicine.NumericalType = NumericalType.百分比;
		medicine.MagicDmg = 1;
		charactor.MedicineList.Add(medicine);
		charactor.Init();
		
}
}

using UnityEngine;
using System.Collections;
using Model;
//using Service;

public class PlayerCharators : Charactors
{

		/// <summary>
		/// 人物初始化
		/// </summary>
		public override void Init ()
		{
				charactor.Name="Player";
				charactor.HP = 100;
				charactor.Crit = 2500;
				charactor.Dodge = 2500;
				//初始化a的武器
				weapon.AttackType = AttackType.近战;
				weapon.DamageType = DamageType.物理;
				weapon.NumericalType = NumericalType.数值;
				weapon.PhysicalDmg = 10;
				weapon.Speed = 1000;
				charactor.Weapon = weapon;
				//初始化a的药剂:
				charactor.MedicineList.Add (medicine);
		

				buff.MagicDef = 1;
				buff.Times = 2;
				buff.NumericalType = NumericalType.数值;
				charactor.BuffList.Add (buff);
				charactor.Init ();
		}
}


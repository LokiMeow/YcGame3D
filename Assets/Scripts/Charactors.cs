using UnityEngine;
using System.Collections;
using Model;
//using Service;

public abstract class Charactors : MonoBehaviour {
	
	protected Transform m_transform;
	//材质:人物图
	public Material m_material;
	//血槽
	protected int hp=100;
	public Vector3 position;
	//绳命
	//protected int life=100;
	private Transform redLife;
	
	//角色
	public Charactor charactor= new Charactor();
	//武器
	protected Weapon weapon=new Weapon();
	//药剂
	protected Medicine medicine=new Medicine();

	protected Buff buff= new Buff();
	

	// Use this for initialization
	void Start () {


		m_transform=this.transform;
		
		redLife=m_transform.FindChild("Life").transform;

		//附材质：显示人物形象
		m_transform.renderer.material=m_material;
		
		//初始化角色
		Init();
		//获得初始血量(最大值)
		hp=charactor.HP;

		if(m_transform.name=="Player")
			charactor.TargetList.Add(GameObject.FindGameObjectWithTag("AI").GetComponent<AICharactors>().charactor);
		if(m_transform.name=="AI")
			charactor.TargetList.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharators>().charactor);
		
	}
	
	// Update is called once per frame
	void Update () {
		//更新血条显示
		LifeUpdate();
		//角色挂了就变暗（置于Dead层不被pointLight照射）
		if(charactor.HP<=0)
				this.gameObject.layer=8;
	}

	
	/// <summary>
	/// 人物初始化(抽象方法)
	/// </summary>
	public abstract void Init();
	
	/// <summary>
	/// 更新血条显示
	/// </summary>
	public void LifeUpdate()
	{
		//血量增减血条x值跟着缩放
		redLife.localScale=new Vector3(m_transform.FindChild("HP").transform.localScale.x*((float)charactor.HP/(float)hp),redLife.localScale.y,redLife.localScale.z);
		//血量增减血条位置左右移动(保持左对齐)
		redLife.position=(new Vector3(m_transform.FindChild("HP").transform.position.x-(m_transform.FindChild("HP").renderer.bounds.size.x-redLife.renderer.bounds.size.x)/2,redLife.position.y,redLife.position.z));
	}


	
}

using UnityEngine;
using System.Collections;

public class ReduceLife : MonoBehaviour {
	/// <summary>
	/// 减少的血量
	/// </summary>
	public string text="";

	/// <summary>
	/// 定时消失
	/// </summary>
	public float timer=3;

	Transform m_transform;

	// Use this for initialization
	void Start () {
		m_transform=this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(text!="")
		{
			timer-=Time.deltaTime;
			m_transform.FindChild("text").GetComponent<GUIText>().text=text;
		}
		if(timer<=0)
			Destroy(this.gameObject);
	}
}

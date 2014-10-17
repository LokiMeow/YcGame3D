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
	public float timer=1.0f;

	Transform m_transform;
	
	Vector3 charactorPosition;
	float up=0;

	// Use this for initialization
	void Start () {
		m_transform=this.transform;
		
		//m_transform.position=Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timer<=0)
			Destroy(this.gameObject);
			
		if(text!="")
		{
			timer-=Time.deltaTime;
			m_transform.FindChild("text").GetComponent<GUIText>().text=text;
			//m_transform.Translate(new Vector3(0,0,0.1f));
			
			charactorPosition=Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
			
			m_transform.position=new Vector3(charactorPosition.x,charactorPosition.y+up,charactorPosition.z);
			
			up+=0.007f;
		}
		
		
			
	}
}

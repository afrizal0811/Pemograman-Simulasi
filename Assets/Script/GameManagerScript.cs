using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour {

	public GameObject go_sudutMeriam;
	public GameObject go_sudutTembak;
	public GameObject go_kecepatanAwal;
	public GameObject go_gravitasi;
	public GameObject go_jarakPeluru;
	public GameObject go_waktuTerbang;
	public GameObject _torque;
	public GameObject _selongsong;
	public float _waktuTerbang;
	public float _jarakTembak;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		go_sudutMeriam.GetComponent<Text> ().text = 
			_torque.GetComponent<TankBehaviorScript> ().sudutMeriam.ToString();

		go_sudutTembak.GetComponent<Text> ().text = 
			_torque.GetComponent<TankBehaviorScript> ().RotasiY.ToString();

		go_gravitasi.GetComponent<Text> ().text = 
			_torque.GetComponent<TankBehaviorScript> ().gravity.ToString ();

		go_kecepatanAwal.GetComponent<Text> ().text = 
			_torque.GetComponent<TankBehaviorScript> ().kecepatanAwal.ToString();

		go_waktuTerbang.GetComponent<Text> ().text = _waktuTerbang.ToString ();

		go_jarakPeluru.GetComponent<Text> ().text = _jarakTembak.ToString ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviorScript : MonoBehaviour {

	private Transform myTransform;
	private string stateRotasiV;
	private float kecepatanRotasi = 20;
	private GameObject titikTembakan;
	private AudioSource audioSource;

	public float kecepatanAwal = 150;

	[HideInInspector] public float RotasiY;
	[HideInInspector] public float sudutMeriam;
	public float gravity = 10;
	public GameObject selongsong;
	public GameObject objekTembakan;
	public GameObject objekLedakan;
	public GameObject peluruMeriam;
	public AudioClip audioTembakan;
	public AudioClip audioLedakan;
	// Use this for initialization
	void Start () {
		myTransform = transform;

		titikTembakan = selongsong.transform.Find ("titiktembakan").gameObject;

		audioSource = selongsong.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		RotasiY = 360 - selongsong.transform.localEulerAngles.x;
		sudutMeriam = 11.587f + myTransform.localEulerAngles.z;

		if (RotasiY == 0 || RotasiY == 360) {
			stateRotasiV = "aman";
		} else if (RotasiY > 0 && RotasiY < 15) {
			stateRotasiV = "aman";
		} else if (RotasiY > 15 && RotasiY < 16) {
			stateRotasiV = "atas";
		} else if (RotasiY > 350) {
			stateRotasiV = "bawah";
		}
		if (stateRotasiV == "aman") {
			if (Input.GetKey (KeyCode.UpArrow)) { // horizontal berlawanan jam
				selongsong.transform.Rotate (Vector3.left * kecepatanRotasi * Time.deltaTime, Space.Self);
				Debug.Log("Up Arrow Pressed");
			} 
			else if(Input.GetKey(KeyCode.DownArrow)) // horizontal jam
			{
				Debug.Log("Down Arrow Pressed");
				selongsong.transform.Rotate (Vector3.right * kecepatanRotasi * Time.deltaTime, Space.Self);
			}
		} else if (stateRotasiV == "bawah") {
			selongsong.transform.localEulerAngles = new Vector3 (
				-0.5f,
				selongsong.transform.localEulerAngles.y, 
				selongsong.transform.localEulerAngles.z 
			);
		} else if (stateRotasiV == "bawah") {
			selongsong.transform.localEulerAngles = new Vector3 (
				-0.5f,
				selongsong.transform.localEulerAngles.y, 
				selongsong.transform.localEulerAngles.z 
			);
		} else if (stateRotasiV == "atas") {
			selongsong.transform.localEulerAngles = new Vector3 (
				-14.5f,
				selongsong.transform.localEulerAngles.y, 
				selongsong.transform.localEulerAngles.z 
			);
		} 

		//kanan-kiri
		if(Input.GetKey(KeyCode.LeftArrow)) // horizontal berlawanan jam
		{
			myTransform.Rotate (Vector3.back * kecepatanRotasi * Time.deltaTime, Space.Self);
			Debug.Log("Left Arrow Pressed");
		}
		else if(Input.GetKey(KeyCode.RightArrow)) // horizontal jam
		{
			myTransform.Rotate (Vector3.forward * kecepatanRotasi * Time.deltaTime, Space.Self);
			Debug.Log("Right Arrow Pressed");
		}

		//Tembakan
		if(Input.GetKeyDown(KeyCode.Space)) // horizontal berlawanan jam
		{
			//peluru
			GameObject peluru = Instantiate(peluruMeriam, titikTembakan.transform.position, 
				Quaternion.Euler (
					(selongsong.transform.localEulerAngles.x + 90), 
					0 ,  
					(-myTransform.localEulerAngles.z - 11 )));
			
			//efek tembakan
			GameObject efekTembakan = Instantiate(objekTembakan, titikTembakan.transform.position, 
			Quaternion.Euler (
				(selongsong.transform.localEulerAngles.x), 
				0 ,  
				(-myTransform.localEulerAngles.z)));

			Destroy (efekTembakan, 1f);

			//efek suara
			audioSource.PlayOneShot(audioTembakan);
		}
		
	}
}


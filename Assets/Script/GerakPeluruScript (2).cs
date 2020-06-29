using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPeluruScript : MonoBehaviour {

	private Transform myTransform;
	private TankBehaviorScript tankBehavior;
	private float _kecAwal;
	private float _sudutTembak;
	private float _sudutMeriam;
	private Vector3 _posisiAwal;
	private AudioSource audioSource;
	private bool isLanded = true;

	public GameManagerScript gameManager;
	public float waktuTerbang;
	public GameObject ledakan;
	public AudioClip audioLedakan;
	// Use this for initialization
	void Start () {
		myTransform = transform;

		tankBehavior = GameObject.FindObjectOfType<TankBehaviorScript> ();
		_kecAwal = tankBehavior.kecepatanAwal;
		_sudutTembak = tankBehavior.RotasiY;
		_sudutMeriam = tankBehavior.sudutMeriam;

		_posisiAwal = myTransform.position;

		audioSource = GetComponent<AudioSource> ();

		gameManager = GameObject.FindObjectOfType<GameManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isLanded)
		waktuTerbang += Time.deltaTime;
		gameManager._waktuTerbang = this.waktuTerbang;

		myTransform.position = PosisiTerbangPeluru (_posisiAwal, _kecAwal, waktuTerbang, 
			_sudutTembak, _sudutMeriam);
	}

	private Vector3 PosisiTerbangPeluru(Vector3 _posisiAwal, float _kecAwal, 
		float _waktu, float _sudutTembak, float _sudutMeriam){

		float _x = _posisiAwal.x + (_kecAwal * _waktu * Mathf.Sin (_sudutMeriam * Mathf.PI / 180));

		float _y = _posisiAwal.y + ((_kecAwal * _waktu * Mathf.Sin(_sudutTembak * Mathf.PI / 180)) 
			- (0.5f * 10 * Mathf.Pow(_waktu, 2)));
		
		float _z = _posisiAwal.z + (_kecAwal * _waktu * Mathf.Cos (_sudutMeriam * Mathf.PI / 180));

		return new Vector3 (_x, _y, _z);
	}

	private void OnTriggerEnter(Collider other){
	
		if( other.tag == "Land"){
			Destroy (this.gameObject, 2f);
		}

		GameObject go = Instantiate (ledakan, myTransform.position, Quaternion.identity);
		Destroy (go, 3f);

		audioSource.PlayOneShot (audioLedakan);

		gameManager._jarakTembak = Vector3.Distance (_posisiAwal, myTransform.position);

		isLanded = false;
	}
}

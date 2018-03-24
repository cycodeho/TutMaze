using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public Slider healthSlider;
	public RawImage damageImage;
	public float flashSpeed = 0.5f;
	public Color flashColor = new Color(1f, 0f, 0f);
	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController playerMovement;
	bool damaged;
	bool isDead;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		playerMovement = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
		damageImage = GameObject.Find ("DamageImage").GetComponents<RawImage>()[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	public void TakeDamge(){
		damaged = true;
		currentHealth -= 1;
		//healthSlider.value = currentHealth; // remaining HP
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}
	public void Death(){
		isDead = true;
		playerMovement.enabled = false;
		// should show a dialog asking whether they want to restart
	}
}

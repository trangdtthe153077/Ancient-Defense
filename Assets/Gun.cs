using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class Gun : Archer
{
	private Tower tower;
	public int manatower;
	public float delay = 20f;
	public int mana = 40;
	public float price = 2000;
	public float level = 1;
	public float dammage = 10;
	public float attackSpeed = 0.75f;
	public readonly float skillAttackSpeed = 0.15f;
	public Button btn;
	GameStateController gameStateController;
	Timer timer;
	Timer delayTimer;
	bool delayFinished = false;
	bool success = false;

	void Start()
	{
		timer = gameObject.AddComponent<Timer>();
		timer.Duration = 1;
		delayTimer = gameObject.AddComponent<Timer>();
		delayTimer.Duration = 5f;
		tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
		manatower = tower.getMana();
		Debug.Log("mana tower: " + manatower);
		Debug.Log("bonk");
		btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
		gameStateController = GameObject.FindWithTag("GameState").GetComponent<GameStateController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (success == true && timer.Finished)
		{
			success = false;
			StopIncreasing();
		}
	}
	public void CallSolider()
	{
		Debug.Log("Skill used!");

	}

	public void LevelUp()
	{
		level += 1;
		mana += 1;
		dammage +=  + 5 / 100;

	}

	public void OnButtonClick()
	{

		Debug.Log("BUtton called");
		if ((manatower - mana >= 0) && success == false && (delayTimer.Finished || delayFinished == false))
		{
			manatower = manatower - mana;
			tower.setMana(manatower);
			Debug.Log("mana: " + manatower);
			delayTimer.Run();
			timer.Run();
			success = true;
			delayFinished = true;
			SkillIncreaseDamage();
		}

	}

	public void SkillIncreaseDamage()
	{


		Archer[] archers = FindObjectsOfType<Archer>();

		foreach (Archer archer in archers)
		{
			archer.Damage = archer.Damage + archer.Damage ;
			Debug.Log("DMG archer:" + archer.Damage);
		}


		// Reset the damage back to its original value


	}
	public void StopIncreasing()
	{

		Archer[] archers = FindObjectsOfType<Archer>();
		foreach (Archer archer in archers)
		{
			archer.Damage = archer.Basedmg;
			Debug.Log("DMG archer:" + archer.Damage);
		}
	}
}

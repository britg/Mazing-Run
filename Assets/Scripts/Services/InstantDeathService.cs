﻿using UnityEngine;
using System.Collections;

public class InstantDeathService {
	
	Player player;
	GameObject obj;
	
	public InstantDeathService (Player _player, GameObject _obj) {
		player = _player;
		obj = _obj;
	}
	
	public void Collide () {
		Debug.Log ("InstantDeath!");
		player.Dead = true;
	}
}
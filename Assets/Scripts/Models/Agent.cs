﻿using UnityEngine;
using System.Collections;

public class Agent : GameModel {

	public enum State {
		Idle,
		Wandering,
		Alert,
		Aggro,
		Controlled
	}

	public int Level { get; set; }
	public float Courage { get; set; }
	public float WanderSpeed { get; set; }
	public float AggroSpeed { get; set; }
	public State CurrentState { get; set; }

	public enum Direction {
		Up,
		Down,
		Right,
		Left,
		Stop
	}

	public float CurrentSpeed { get; set; }
	public Direction CurrentDirection { get; set; }
	public Vector3 Velocity { get { return CurrentSpeed * DirectionVector; } }
	public Vector3 DirectionVector {
		get {
			if (CurrentDirection == Agent.Direction.Up) {
				return Vector3.forward;
			}
			if (CurrentDirection == Agent.Direction.Right) {
				return Vector3.right;
			}
			if (CurrentDirection == Agent.Direction.Left) {
				return Vector3.left;
			}
			if (CurrentDirection == Agent.Direction.Down) {
				return Vector3.back;
			}
			if (CurrentDirection == Agent.Direction.Stop) {
				return Vector3.zero;
			}
			
			return Vector3.zero;
		}
	}

	public void EnterState (Enemy.State newState) {
		CurrentState = newState;

		if (CurrentStateWandering) {
			CurrentSpeed = WanderSpeed;
		}

		if (CurrentStateAggro) {
			CurrentSpeed = AggroSpeed;
		}

		if (CurrentStateIdle || CurrentStateAlert) {
			CurrentSpeed = 0f;
		}
	}

	public bool CurrentStateIdle {
		get {
			return CurrentState == Enemy.State.Idle;
		}
	}

	public bool CurrentStateWandering {
		get {
			return CurrentState == Enemy.State.Wandering;
		}
	}

	public bool CurrentStateAlert {
		get {
			return CurrentState == Enemy.State.Alert;
		}
	}

	public bool CurrentStateAggro {
		get {
			return CurrentState == Enemy.State.Aggro;
		}
	}

	public bool CurrentStateControlled {
		get {
			return CurrentState == Enemy.State.Controlled;
		}
	}

}

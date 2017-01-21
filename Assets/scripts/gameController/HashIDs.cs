using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	// tutorial variables
	public int dyingState;
	public int deadBool;
	public int locomotionState;
	public int shoutState;
	public int speedFloat;
	public int sneakingBool;
	public int shoutingBool;
	public int playerInSightBool;
	public int shotFloat;
	public int aimWeightFloat;
	public int angularSpeedFloat;
	public int openBool;

	// my variables

	// states
	public int idleState;
	public int walkState;
	public int blockState;
	public int lhSwingState;
	public int rhSwingState;
	public int dblVertSwingState;
	public int thorState;
	public int logiState;

	// parameters
	public int dblVertSwingBool;
	public int movingBool;
	public int dblVertSwingTrig;
	public int rhSwingTrig;
	public int lhSwingTrig;
	public int blockBool;
	public int thorTrig;
	public int logiTrig;

	void Awake() {
		// tutorial variable assignment
		dyingState = Animator.StringToHash ("Base Layer.Dying");
		deadBool = Animator.StringToHash ("Dead");
		locomotionState = Animator.StringToHash ("Base Layer.Locomotion");
		shoutState = Animator.StringToHash ("Shouting.Shout");
		speedFloat = Animator.StringToHash ("Speed");
		sneakingBool = Animator.StringToHash ("Sneaking");
		shoutingBool = Animator.StringToHash ("Shouting");
		playerInSightBool = Animator.StringToHash ("PlayerInSight");
		shotFloat = Animator.StringToHash ("Shot");
		aimWeightFloat = Animator.StringToHash ("AimWeight");
		angularSpeedFloat = Animator.StringToHash ("AngularSpeed");
		openBool = Animator.StringToHash ("Open");

		// my variable assignment

		// states
		idleState = Animator.StringToHash ("Base Layer.Idle");
		walkState = Animator.StringToHash ("Base Layer.Walk");
		blockState = Animator.StringToHash ("Base Layer.Block");
		lhSwingState = Animator.StringToHash ("Base Layer.LH_Swing");
		rhSwingState = Animator.StringToHash ("Base Layer.RH_Swing");
		dblVertSwingState = Animator.StringToHash ("Base Layer.DblVertSwing");
		thorState = Animator.StringToHash ("Base Layer.ThorsThunder");
		logiState = Animator.StringToHash ("Base Layer.LogisFlame");

		// parameters
		dblVertSwingBool = Animator.StringToHash ("DoubleVerticalSwing");
		movingBool = Animator.StringToHash ("Moving");
		dblVertSwingTrig = Animator.StringToHash ("DoubleVerticalSwingTrigger");
		rhSwingTrig = Animator.StringToHash ("RightHandSwingTrigger");
		lhSwingTrig = Animator.StringToHash ("LeftHandSwingTrigger");
		blockBool = Animator.StringToHash ("Block");
		thorTrig = Animator.StringToHash ("ThorTrigger");
		logiTrig = Animator.StringToHash ("LogiTrigger");

	}
}

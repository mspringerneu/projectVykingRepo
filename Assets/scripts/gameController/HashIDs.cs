using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	// vyking_animator state variables
	public int idleState;
	public int walkState;
	public int dyingState;
	public int emptyBlockingState;
	public int blockingState;
	public int emptyMeleeAttackState;
	public int leftHandSwingState;
	public int rightHandSwingState;
	public int doubleVerticalSwingState;
	public int emptyManaState;
	public int thorsThunderState;
	public int logisFlameState;

	// vyking_animator parameter variables
	public int movingBool;
	public int deadBool;
	public int blockingBool;
	public int leftHandSwingTrigger;
	public int rightHandSwingTrigger;
	public int doubleVerticalSwingTrigger;
	public int thorsThunderTrigger;
	public int logisFlameTrigger;

	// enemyAI_animator tutorial parameter variables
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


	void Awake() {
		// vyking_animator state variables
		idleState = Animator.StringToHash ("Base Layer.vyking_idle");
		walkState = Animator.StringToHash ("Base Layer.vyking_walk");
		dyingState = Animator.StringToHash ("Base Layer.vyking_dying");
		emptyBlockingState = Animator.StringToHash ("Blocking.vyking_emptyBlocking");
		blockingState = Animator.StringToHash ("Blocking.vyking_blocking");
		emptyMeleeAttackState = Animator.StringToHash ("MeleeAttack.vyking_emptyMeleeAttack");
		leftHandSwingState = Animator.StringToHash ("MeleeAttack.vyking_emptyMeleeAttack");
		rightHandSwingState = Animator.StringToHash ("MeleeAttack.vyking_emptyMeleeAttack");
		doubleVerticalSwingState = Animator.StringToHash ("MeleeAttack.vyking_emptyMeleeAttack");
		emptyManaState = Animator.StringToHash ("ManaAttack.vyking_emptyManaAttack");
		thorsThunderState = Animator.StringToHash ("ManaAttack.vyking_thorsThunder");
		logisFlameState = Animator.StringToHash ("ManaAttack.vyking_logisFlame");

		// vyking_animator parameter variables
		movingBool = Animator.StringToHash ("Moving");
		deadBool = Animator.StringToHash ("Dead");
		blockingBool = Animator.StringToHash ("Blocking");
		leftHandSwingTrigger = Animator.StringToHash ("LeftHandSwing");
		rightHandSwingTrigger = Animator.StringToHash ("RightHandSwing");
		doubleVerticalSwingTrigger = Animator.StringToHash ("DoubleVerticalSwing");
		thorsThunderTrigger = Animator.StringToHash ("ThorsThunder");
		logisFlameTrigger = Animator.StringToHash ("LogisFlame");

		locomotionState = Animator.StringToHash("Base Layer.Locomotion");
		shoutState = Animator.StringToHash("Shouting.Shout");
		speedFloat = Animator.StringToHash("Speed");
		sneakingBool = Animator.StringToHash("Sneaking");
		shoutingBool = Animator.StringToHash("Shouting");
		playerInSightBool = Animator.StringToHash("PlayerInSight");
		shotFloat = Animator.StringToHash("Shot");
		aimWeightFloat = Animator.StringToHash("AimWeight");
		angularSpeedFloat = Animator.StringToHash("AngularSpeed");
		openBool = Animator.StringToHash("Open");
	}
}

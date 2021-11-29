using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;

		[SerializeField]
		float targetRange = 10f;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			target = GameObject.FindWithTag("Player").GetComponent<Transform>();
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if(CanSeePlayer() == true){
				ai.destination = target.position;
			}
		}
		public bool CanSeePlayer(){
			bool sees = false;
			if(Vector2.Distance(transform.position, target.position) < targetRange){
				RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, 1 << LayerMask.NameToLayer("Walls"));
				if(hit.collider != null){
					if(hit.collider.gameObject.CompareTag("Player")){
						sees = true;
					}
					else if(hit.collider.gameObject.CompareTag("Walls")){
						sees = false;
					}
					Debug.DrawLine(transform.position, target.position, Color.blue);
				}
			}
			return sees; 
		}
	}
}

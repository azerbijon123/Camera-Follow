using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent navAgent;
	Animator anim;

	public float rayCastLength;
	public AbilityMenu abilityMenu;
	public InventoryMenu inventoryMenu;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		abilityMenu = GetComponent<AbilityMenu> ();
		inventoryMenu = GetComponent<InventoryMenu> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
		AnimatorMove ();
	}
    //Remove comment when the ability menu is being used.
	/*void Movement(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Input.GetMouseButtonUp (0)) {
			if (Physics.Raycast (ray, out hit, rayCastLength) && !abilityMenu.isVisible && !inventoryMenu.isVisible) {
				if (hit.collider.tag.Equals ("Environment")) {
					navAgent.SetDestination (hit.point);
				} else if (hit.collider.tag.Equals ("Enemy")) {

				} else if (hit.collider.tag.Equals ("UserInterface")) {
					Debug.Log ("Hit the user interface");
				}
			}
		}
	}*/
    void Movement()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, rayCastLength))
            {
                if (hit.collider.tag.Equals("Environment"))
                {
                    navAgent.SetDestination(hit.point);
                }
                else if (hit.collider.tag.Equals("Enemy"))
                {

                }
                else if (hit.collider.tag.Equals("UserInterface"))
                {
                    Debug.Log("Hit the user interface");
                }
            }
        }
    }

    void AnimatorMove(){
		float velocity = navAgent.velocity.magnitude;
		if (velocity > 0.8f) {
			anim.SetBool("Walking", true);
		} else {
			anim.SetBool("Walking", false);
		}
	}

}

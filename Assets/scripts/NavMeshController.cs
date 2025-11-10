using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public GameObject Target;
    public GameObject dagger;
    public GameObject axe;
    public GameObject heldAxe;
    public GameObject heldDagger;
    public Transform holdPoint;
    private NavMeshAgent agent;
    public Animator camAnim;
    Animator anim;

    private bool isHoldingAxe = false;
    private bool isHoldingDagger = false;
    private bool hasDagger = false;
    private bool hasAxe = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
        agent.destination = Target.transform.position;
        SwitchWeapons();
        
        

    }

    private void OnTriggerEnter(Collider other)      //if it hits the target
    {

        if (other.name == "Dagger" || other.name == "Dagger")
        {
            Debug.Log("PickUp");
            if (!isHoldingDagger)
            {
                isHoldingAxe = false;
                    hasDagger = true;
                    isHoldingDagger = true;
                heldDagger = Instantiate(dagger, holdPoint.position, holdPoint.rotation, holdPoint);
                Destroy(other.gameObject);
            }
            
        }
        if (other.name == "Axe")
        {
            if (!isHoldingAxe)
            {
                heldAxe = Instantiate(axe, holdPoint.position, holdPoint.rotation, holdPoint);

                isHoldingDagger = false;
                hasAxe = true;
                isHoldingAxe = true;
                Destroy(other.gameObject);
            }
            else if (isHoldingDagger && !isHoldingAxe)
            {
                isHoldingDagger = false;
                isHoldingAxe = true;
            }

        }

        if (other.name == "Target")
        {
            anim.SetFloat("Blend", 0);
        }

        if (other.name == "CamSpace1")
        {
            camAnim.SetTrigger("Move");
        }
        if (other.name == "CamSpace2")
        {
            camAnim.SetTrigger("Move2");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Target")
        {
            anim.SetFloat("Blend", 1);
        }
    }

    void SwitchWeapons()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isHoldingDagger = false;
            isHoldingAxe = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isHoldingDagger = true;
            isHoldingAxe = false;
            anim.SetLayerWeight(1, 0.75f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && hasAxe)
        {
            isHoldingDagger = false;
            isHoldingAxe = true;
        }

        if (isHoldingDagger && !isHoldingAxe)
        {
            if (hasAxe)
            {
                heldAxe.SetActive(false);
            }
            heldDagger.gameObject.SetActive(true);
        }
        else if (!isHoldingDagger && hasDagger)
        {
            heldDagger.SetActive(false);
        }

        if (isHoldingAxe && !isHoldingDagger)
        {
            heldAxe.SetActive(true);
            heldDagger.SetActive(false);
        }
        else if (!isHoldingAxe && hasAxe)
        {
            heldAxe.SetActive(false);

        }


            if (!isHoldingAxe && hasAxe && !isHoldingDagger && hasDagger)
            {
                try
                {
                    heldDagger.SetActive(false);
                    heldAxe.SetActive(false);
                }
                catch
                { }
            }
        
    }

}

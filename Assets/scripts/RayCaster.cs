using UnityEngine;
using UnityEngine.AI;

public class RayCaster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] NavMeshController nav;
 
    [SerializeField] Camera cam;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nav = GetComponent<NavMeshController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.point);  //point is a position x,y,z  e.g. this.transform.position = hit.point
                nav.Target.transform.position = hit.point;
            }       
        }
    }
}

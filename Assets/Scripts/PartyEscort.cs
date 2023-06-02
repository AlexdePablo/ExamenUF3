using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartyEscort : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool patroling;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;
    private bool yendoAl1;
    // Start is called before the first frame update
    void Start()
    {
        yendoAl1 = true;
        navMeshAgent= GetComponent<NavMeshAgent>(); 
        patroling= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (patroling)
        {
            if (yendoAl1)
                navMeshAgent.destination = pos1.position;
            else
                navMeshAgent.destination = pos2.position;
        }
        else
        {
            navMeshAgent.destination = player.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Chell>().GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
           patroling= false;    
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("posiciones"))
        {
            if (other.tag == "Pos1")
                yendoAl1 = false;
            if (other.tag == "Pos2")
                yendoAl1 = true;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            patroling = true;
        }
    }
}

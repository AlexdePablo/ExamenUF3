using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chell : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PortalBlauPrefab;
    private GameObject m_PortalBlau;
    [SerializeField]
    private GameObject m_PortalTaronjaPrefab;
    private GameObject m_PortalTaronja;
    private bool azulSpawned;
    private bool naranjaSpawned;
    [SerializeField]
    private Transform m_Camera;
    // Start is called before the first frame update
    void Start()
    { 
        azulSpawned = false;
        naranjaSpawned= false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnPortalAzul();
        if (Input.GetMouseButtonDown(1))
            SpawnPortalTaronja();

    }
    private void SpawnPortalAzul()
    {
        RaycastHit hit;
        Physics.Raycast(m_Camera.position, m_Camera.forward, out hit, Mathf.Infinity );
        if (!azulSpawned)
        {
            m_PortalBlau = Instantiate(m_PortalBlauPrefab);
            azulSpawned= true;
        }
        m_PortalBlau.transform.position = hit.point;
        m_PortalBlau.transform.forward = hit.normal;
    }
    private void SpawnPortalTaronja()
    {
        RaycastHit hit;
        Physics.Raycast(m_Camera.position, m_Camera.forward, out hit, Mathf.Infinity);
        if (!naranjaSpawned)
        {
            m_PortalTaronja = Instantiate(m_PortalTaronjaPrefab);
            naranjaSpawned= true;
        }
        m_PortalTaronja.transform.position = hit.point;
        m_PortalBlau.transform.forward = hit.normal;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "portal")
        {
            print("He tocat un portal!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Chell: " + collision.transform.tag);

        if (collision.transform.tag == "cake")
        {
            print("The cake is a lie!");
        }
    }

    public void GameOver()
    {
        print("Game over");
        Destroy(this.gameObject);
    }
}

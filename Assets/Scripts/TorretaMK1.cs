using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaMK1 : MonoBehaviour
{
    [SerializeField]
    private GameObject m_VisorTorreta;
    private float rotacion;
    private bool derechando;
    private RaycastHit hit;
    private bool rotating;

    // Start is called before the first frame update
    void Start()
    {
        rotating= true;    
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(m_VisorTorreta.transform.position, m_VisorTorreta.transform.forward, out hit, Mathf.Infinity);
        if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine("Disparar");
        }
        if (rotating)
        {
            if (derechando)
            {
                m_VisorTorreta.transform.localEulerAngles = new Vector3(0, m_VisorTorreta.transform.localEulerAngles.y + 0.2f, 0);
                rotacion += 0.2f;
                if (rotacion >= 30)
                {
                    derechando = false;
                }
            }
            else
            {
                m_VisorTorreta.transform.localEulerAngles = new Vector3(0, m_VisorTorreta.transform.localEulerAngles.y - 0.2f, 0);
                rotacion -= 0.2f;
                if (rotacion <= -30)
                {
                    derechando = true;
                }
            }
        }
       
    }
    private IEnumerator Disparar()
    {
        rotating = false;
        Debug.DrawRay(m_VisorTorreta.transform.position, m_VisorTorreta.transform.forward, Color.red, 5);
        yield return new WaitForSeconds(1);
        Physics.Raycast(m_VisorTorreta.transform.position, m_VisorTorreta.transform.forward, out hit, Mathf.Infinity);
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("player muerto");
        }
        rotating= true;
    }
}
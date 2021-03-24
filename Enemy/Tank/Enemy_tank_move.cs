using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Enemy_tank_move : MonoBehaviour
{
    private NavMeshAgent _agent;

    private GameObject Player;

    //砲身だけを回転させるために取得
    [SerializeField]
    private GameObject Tank_turret;

    private float Lerp_value;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player != null)
        {
            _agent.destination = Player.transform.position;
            _agent.SetDestination(Player.transform.position);

            var Q1 = Tank_turret.transform.rotation;
            var Q2 = Quaternion.LookRotation(Player.transform.position - Tank_turret.transform.position);

            Tank_turret.transform.rotation = Quaternion.Slerp(Q1,Q2,Time.deltaTime * Lerp_value);
        }
        
    }
    public void Set_Lerp_value(float _Lerp_value){
        Lerp_value = _Lerp_value;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player != null) Player = null;
        }
    }

}

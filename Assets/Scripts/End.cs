using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public bool ends = false;
    private Animator _anim;
    [SerializeField] GameObject _Win;
    [SerializeField] GameObject _Panel;


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            
            _anim.SetBool("ends", true);
            GetComponent<Move>().enabled=false; //compenent kapatma işlemi
            _Win.SetActive(true);
            _Panel.SetActive(true);

        }
    }
}
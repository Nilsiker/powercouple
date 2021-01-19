using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdController : MonoBehaviour
{
    NavMeshAgent nav;
    Animator anim;
    Mover mover;

    [SerializeField] bool flying = false;   // TODO remove debug
    [SerializeField] bool hungry = false;   // TODO remove debug
    [SerializeField] float flyingHeight = 1f;
    [SerializeField] float riseSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flying)
        {
            GetComponent<Rigidbody>().useGravity = !flying;
            if (transform.position.y < flyingHeight)
            {
                mover.AbsoluteMove(Vector3.up * riseSpeed * Time.fixedDeltaTime);
            }
            else if (transform.position.y > flyingHeight)
            {
                mover.AbsoluteMove(Vector3.down * riseSpeed * Time.fixedDeltaTime);
            }
        }

        if (hungry)
        {

        }
    }
}

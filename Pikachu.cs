using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikachu : MonoBehaviour {

    public float speed;

    private Animator anim;
    string moveState;
    private float totalTime = 0;
    bool moving = false;
    private Vector3 direction;
    private Vector3 movement;
    private UnityEngine.AI.NavMeshAgent agent;
    private Vector2 randomPoint;
    private int rand;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = gameObject.GetComponentInChildren<Animator>();

        randomPoint = Random.insideUnitCircle * 100;
        randomPoint.Normalize();
        direction = new Vector3(randomPoint.x, 0.0f, randomPoint.y);
    }


    void Update() {

        totalTime += Time.deltaTime;
        agent.SetDestination(direction);
        Move();

    }

    void Move(){

        if (totalTime > 10)
        {
            totalTime = 0;
            randomPoint = Random.insideUnitCircle * 100;
            randomPoint.Normalize();
            direction = new Vector3(randomPoint.x, 0.0f, randomPoint.y);

            rand = Random.Range(1, 3);
            if (rand == 1)
            {
                agent.Stop();
                inPlaceAnim();
            }
            else moveAnim();
        }

    }

    void inPlaceAnim()
    {
        //pick state
        moveState = string.Format("Move0{0}", Random.Range((int)4, (int)6));
        //play animation
        anim.Play(moveState);

    }

    void moveAnim()
    {
        //pick state
        moveState = string.Format("Move0{0}", Random.Range((int)2, (int)4));
        //set direction
        agent.SetDestination(direction);
        //play animation
        anim.Play(moveState);


    }

}

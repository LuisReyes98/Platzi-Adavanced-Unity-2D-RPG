using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1;
    private Rigidbody2D enemyRigidbody;

    private bool isMoving = false;

    public float timeBetweenSteps;

    private float timeBetweenStepsCounter;

    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;
    private Vector2 lastMovement = Vector2.zero;

    private Animator enemyAnimator;

    private const string horizontal = "Horizontal";

    private const string vertical = "Vertical";
    private const string moving = "isMoving";

    private const string lastHorizontal = "LastHorizontal";

    private const string lastVertical = "LastVertical";

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRigidbody.velocity = directionToMakeStep;

            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                directionToMakeStep = new Vector2(
                    Random.Range(-5, 5) > 0 ? 1 : -1,
                    Random.Range(-5, 5) > 0 ? 1 : -1
                ) * enemySpeed;

                lastMovement = directionToMakeStep;
            }
        }

        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);

        if (lastMovement != Vector2.zero)
        {
            enemyAnimator.SetBool(moving, isMoving);
        }

        enemyAnimator.SetFloat(lastHorizontal, lastMovement.x);

        enemyAnimator.SetFloat(lastVertical, lastMovement.y);
    }
}

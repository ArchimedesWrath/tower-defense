using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

    public float speed = 5f;
    private bool moving = false;
    private bool movingX = false;
    private bool movingY = false;
    private bool chosen = false;
    private int choice = 0;
    private Vector3 currentWaypoint;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (currentWaypoint == Vector3.zero) moving = false;

        if (currentWaypoint != Vector3.zero)
        {
            moving = true;
            MovePlayer();
        }

        if (moving) Debug.Log("moving");

		if (Input.GetMouseButtonDown(1) && currentWaypoint != Vector3.zero)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetWaypoint(mousePos);
        }
	}

    private void SetWaypoint(Vector2 mousePos)
    {
        currentWaypoint = mousePos;
    }

    private void MovePlayer()
    {
        Vector2 dir = currentWaypoint - transform.position;

        if (!chosen)
        {
            choice = Smaller(dir);
            chosen = true;
        }

        if (choice == 1)
        {
            if (!movingY) transform.Translate(new Vector2(dir.x, 0).normalized * speed * Time.deltaTime);

            if (Mathf.Abs(dir.x) <= 0.1f)
            {
                movingY = true;
                transform.Translate(new Vector2(0, dir.y).normalized * speed * Time.deltaTime);

                if (Mathf.Abs(dir.y) <= 0.1f)
                {
                    movingY = false;
                    chosen = false;
                    choice = 0;
                    currentWaypoint = Vector2.zero;
                }
            }
        } else if (choice == 2)
        {
            if (!movingX) transform.Translate(new Vector2(0, dir.y).normalized * speed * Time.deltaTime);

            if (Mathf.Abs(dir.y) <= 0.1f)
            {
                movingX = true;
                transform.Translate(new Vector2(dir.x, 0).normalized * speed * Time.deltaTime);

                if (Mathf.Abs(dir.x) <= 0.1f)
                {
                    movingX = false;
                    chosen = false;
                    choice = 0;
                    currentWaypoint = Vector2.zero;
                }
            }
        }
    }

    private int Smaller(Vector2 dir)
    {
        if (dir.x <= dir.y)
        {
            return 1;
        } else
        {
            return 2;
        }
    }
}

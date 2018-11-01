using UnityEngine;
using UnityEngine.EventSystems;


public class Grass : MonoBehaviour {

    private Color hoverColor = new Color(0.9f, 0.9f, 0.9f);
    private Color noCashColor = new Color(1f, 0.5f, 0.5f);

    [Header("Optional")]
    public GameObject tower;

    private SpriteRenderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasCash)
        {
            rend.color = hoverColor;
        } else
        {
            rend.color = noCashColor;
        }

        if(tower != null)
        {
            Debug.Log("Turret already built here! - TODO: Display on screen.");
            return;
        }

        buildManager.BuildTowerOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; 

        if (!buildManager.CanBuild) return;

        rend.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.color = startColor;
    }
}

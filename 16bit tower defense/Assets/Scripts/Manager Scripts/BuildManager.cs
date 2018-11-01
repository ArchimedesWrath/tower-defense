using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager in scene");
            return;
        }

        instance = this;
    }

    public GameObject WoodPrefab;
    public GameObject DewDropPrefab;

    public GameObject BuildEffect;

    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null;  } }
    public bool HasCash { get { return PlayerStats.Cash >= towerToBuild.cost; } }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }

    public void BuildTowerOn(Grass node)
    {
        if (PlayerStats.Cash < towerToBuild.cost)
        {
            Debug.Log("Not enough to purchase tower");
            return;
        }

        PlayerStats.Cash -= towerToBuild.cost;

        Vector3 placement = new Vector3(node.GetBuildPosition().x, node.GetBuildPosition().y, node.GetBuildPosition().z - 1);
        Quaternion rotation = node.transform.rotation;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, placement, rotation);
        node.tower = tower;

        GameObject effect = (GameObject)Instantiate(BuildEffect, placement, rotation);
        Destroy(effect, 1f);
    }
}
    
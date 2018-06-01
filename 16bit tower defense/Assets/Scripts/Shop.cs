using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TowerBlueprint dewTower;
    public TowerBlueprint woodTower;
    public TowerBlueprint sandTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectWoodTower()
    {
        buildManager.SelectTowerToBuild(woodTower);
    }

    public void SelectDewDropTower()
    {
        buildManager.SelectTowerToBuild(dewTower);
    }

    public void SelectSandTower()
    {
        buildManager.SelectTowerToBuild(sandTower);
    }
}

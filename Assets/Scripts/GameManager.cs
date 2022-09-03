using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public Vector3[] packageSpawnLocations = new Vector3[3];
    public Vector3[] customerSpawnLocations = new Vector3[3];
    public Vector3[] boostSpawnLocations = new Vector3[5];

    [SerializeField] private GameObject packages;
    [SerializeField] private GameObject customers;
    [SerializeField] private GameObject boost;
    [SerializeField] private GameObject car;
    
    private bool packageActive;
    private bool customerWaiting;
    

    private SpawnManager packageSpawner;
    private SpawnManager customerSpawner;
    private SpawnManager boostSpawner;
    private DeliveryController _deliveryController;

    // Start is called before the first frame update
    void Start()
    {
        _deliveryController = car.GetComponent<DeliveryController>();
        packageSpawner = new SpawnManager(packageSpawnLocations, packages, false, 1f, 1);
        customerSpawner = new SpawnManager(customerSpawnLocations, customers, false, 1f, 1);
        boostSpawner = new SpawnManager(boostSpawnLocations, boost, true, 7f, 3);
        
        InvokeRepeating("SpawnBoosts", 1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!customerWaiting)
        {
            SpawnCustomer();
            customerWaiting = true;
            _deliveryController._deliveredPackage = false;
        }
        if (!packageActive && !_deliveryController._gotPackage)
        {
            SpawnPackages();
            packageActive = true;
        }

        if (_deliveryController._deliveredPackage)
        {
            customerWaiting = false;
            packageActive = false;
        }
    }

    private void SpawnBoosts()
    {
        boostSpawner.Spawn();
    }

    private void SpawnPackages()
    {
        packageSpawner.Spawn();
    }

    private void SpawnCustomer()
    {
        customerSpawner.Spawn();
    }
}

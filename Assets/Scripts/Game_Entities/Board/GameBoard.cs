using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class GameBoard : MonoBehaviour
{

    // NumberTiles must be % 4 == 0 ;
    public const int NumberTiles_Rat_Race = 18;
    public const int NumberTiles_Fat_Race = 32;
    public static GameBoard Instance;
    // Avatar Tile -- Prefabs;
    [SerializeField] private GameObject Tile;
    [SerializeField] public Tile_Material tile_avatar;
    // Size of Tile
    public float size = 1f;
    // Radius of Rat Race
    public float radius = 2f;
    // List Tile
    public List<GameObject> Tiles_Rat_Race;
    public List<GameObject> Tiles_Fat_Race;
    public GameObject Root;



    // Excecute when Loading Scence
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        SpawnTiles();
    }


    private void Start()
    {
        
    }

    // Spawn Tile with number has been create
    [Obsolete]
    private void SpawnTiles()
    {
        Transform rootPos = Root.GetComponent<Transform>();
        rootPos.position = new Vector3(0, 0, 0);
        // Spawn Rat Race with Circle
        Spawn_Rat_Race(NumberTiles_Rat_Race);
        // Spawn Fat Race with Square
        Spawn_Fat_Race(NumberTiles_Fat_Race);
        // Set Event Type to All Race , TMP is RAT RACE
        Set_Tiles_Type();
    }

    public void Set_Tiles_Type()
    {
        Server_Connection_Helper helper = new Server_Connection_Helper();
        StartCoroutine(helper.Get("Tiles/tile", (request,process) =>
        {
            Debug.Log(request.downloadHandler.text);
            List<Tile_Entity> tiles = ParseJsonToListTile(request);
            Debug.Log(string.Format("Downloaded Tiles Process {0:P1}", process * 100f + "%"));
            foreach (Tile_Entity tile in tiles)
            {
                switch (tile.race_type)
                {
                    case "FAT":
                        Set_Fat_Race_Tile_Event(tile);
                        break;
                    default:
                        Set_Rat_Race_Tile_Event(tile);
                        break;
                }
            }
        }));
        
    }

    [Obsolete]
    private void Spawn_Rat_Race(int NumberTiles_Rat_Race)
    {
        Tiles_Rat_Race = new List<GameObject>();
        float nextAngle = 2 * Mathf.PI / NumberTiles_Rat_Race;
        float angle = 0;// start pos
        for (int i = 0; i < NumberTiles_Rat_Race; i++)
        {
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            GameObject tile = Instantiate(Tile, new Vector3(-x*size, 0f, z*size), Quaternion.identity);
            tile.transform.rotation = Quaternion.EulerAngles(0f, angle, 0f);
            tile.transform.parent = this.transform;
            Tiles_Rat_Race.Add(tile);
            angle += nextAngle;
        }
    }   

    private List<Tile_Entity> ParseJsonToListTile(UnityWebRequest webRequest)
    {
        List<Tile_Entity> list = new List<Tile_Entity>();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(": Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(": HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                list = JsonConvert.DeserializeObject<List<Tile_Entity>>(webRequest.downloadHandler.text);
                break;
            default:
                break;
        }
        return list;
    }

    private void Set_Rat_Race_Tile_Event(Tile_Entity tile)
    {
        TileType type;
        switch (tile.tile_type)
        {
            case "PayCheck":
                type = TileType.PayCheck;
                break;
            case "Get A Child":
            case "DowSize":
                type = TileType.DownSize;
                break;
            case "The Market":
                type = TileType.Doodads;
                break;
            case "Charity":
                type = TileType.Charity;
                break;
            default:
                type = TileType.Oppotunity;
                break;
        }
        foreach(int i in tile.positions)
        {
            Tiles_Rat_Race[i].GetComponent<Tile>().Type = type;
            Tiles_Rat_Race[i].GetComponent<Tile>().SetMaterialTile(type,tile_avatar);
        }
    }
    private void Set_Fat_Race_Tile_Event(Tile_Entity tile)
    {
        TileType type;
        switch (tile.tile_type)
        {
            case "PayCheck":
                type = TileType.PayCheck;
                break;
            case "Get A Child":
            case "DowSize":
                type = TileType.DownSize;
                break;
            case "Charity":
                type = TileType.Charity;
                break;
            case "The Market":
            case "Doodad":
                type = TileType.Doodads;
                break;
            default:
                type = TileType.Oppotunity;
                break;
        }
        foreach (int i in tile.positions)
        {
            Tiles_Fat_Race[i].GetComponent<Tile>().Type = type;
            Tiles_Fat_Race[i].GetComponent<Tile>().SetMaterialTile(type,tile_avatar);
        }
    }

    private void Spawn_Fat_Race(int NumberTiles_Fat_Race)
    {
        Tiles_Fat_Race = new List<GameObject>();
        float nextQuare = NumberTiles_Fat_Race / 4;
        float quare = nextQuare / 2;// start pos
        for (int i = 0; i < NumberTiles_Fat_Race; i++)
        {
            //float x = 
            GameObject tile;
            if (i <= nextQuare)
            {
                tile = Instantiate(Tile, new Vector3(size * (quare  - i), 0f,-size * quare), Quaternion.identity);
            }
            else if (i > nextQuare && i <= nextQuare * 2)
            {
                tile = Instantiate(Tile, new Vector3(size * (quare-nextQuare), 0f, size * (i-nextQuare-quare)), Quaternion.Euler(0,90f,0));
            }
            else if (i > (nextQuare * 2) && i <= (nextQuare * 3))
            {
                tile = Instantiate(Tile, new Vector3(size * (i-(nextQuare*2+quare)), 0f, size * (nextQuare - quare)), Quaternion.Euler(0f, 180f, 0f));
            }
            else
            {
                tile = Instantiate(Tile, new Vector3(size * quare, 0f, size * (4 * nextQuare - i-quare)), Quaternion.Euler(0f, -90f, 0f));
            }

            tile.transform.parent = this.transform;
            Tiles_Fat_Race.Add(tile);
        }
    }
}

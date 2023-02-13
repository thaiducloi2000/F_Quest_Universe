using UnityEngine;
using TMPro;


public enum TileType { Oppotunity, Charity, PayCheck, Offer,DownSize,Doodads };

public class Tile : MonoBehaviour
{

    public TileType Type;
    public TextMeshPro titles;
    public Tile_Material default_material;

    private void Start()
    {
        this.gameObject.transform.localScale *= GameBoard.Instance.size;
        SetMaterialTile(this.Type, default_material);
    }


    public void SetMaterialTile(TileType type,Tile_Material material)
    {
        switch (type)
        {
            case TileType.Oppotunity:
                this.gameObject.GetComponent<Renderer>().material = material.oppotunity_material;
                titles.text = "Oppotunity";
                break;
            case TileType.Charity:
                this.gameObject.GetComponent<Renderer>().material = material.charity_material;
                titles.text = "Charity";
                break;
            case TileType.PayCheck:
                this.gameObject.GetComponent<Renderer>().material = material.paycheck_material;
                titles.text = "PayCheck";
                break;
            case TileType.Offer:
                this.gameObject.GetComponent<Renderer>().material = material.offer_material;
                titles.text = "Offer";
                break;
            case TileType.DownSize:
                this.gameObject.GetComponent<Renderer>().material = material.downsize_material;
                titles.text = "DownSize";
                break;
            case TileType.Doodads:
                this.gameObject.GetComponent<Renderer>().material = material.doodads_material;
                titles.text = "Doodads";
                break;
            default:
                this.gameObject.GetComponent<Renderer>().material = material.default_material;

                titles.text = "";
                break;
        }
    }
}

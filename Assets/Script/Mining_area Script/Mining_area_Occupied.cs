using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining_area_Occupied : MonoBehaviour
{
    static Mining_area_Occupied mining_Area_Occupied;
    //public Material _material_0, _material_1;
    private void Awake()
    {
        if (mining_Area_Occupied == null)
        {
            mining_Area_Occupied = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void Occupied(GameObject thisgameObject, Material material)
    {
        thisgameObject.GetComponent<MeshRenderer>().material = material;
    }
}

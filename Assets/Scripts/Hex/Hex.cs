using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    private HexCoordinates hexCoordinates;

    public Vector3Int HexCoords => hexCoordinates.GetHexCoords();

    private void Awake() {
        hexCoordinates = GetComponent<HexCoordinates>();
    }
}

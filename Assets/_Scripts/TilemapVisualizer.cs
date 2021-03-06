using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    public List<Vector2Int> spawnList;
    public List<Vector2Int> leftWalls, rightWalls, upWalls, downWalls, leftDownCornerWalls, rightDownCornerWalls, rightUpCornerWalls, leftUpCornerWalls, fullWalls;

    [SerializeField]
    public TileBase floorTile, wallTop, wallSideRight, wallSiderLeft, wallBottom, wallFull, 
        wallInnerCornerDownLeft, wallInnerCornerDownRight, 
        wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {   
        spawnList.Clear();
        upWalls.Clear();
        downWalls.Clear();
        rightWalls.Clear();
        leftWalls.Clear();
        leftDownCornerWalls.Clear();
        rightDownCornerWalls.Clear();
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {   
            if (tilemap == floorTilemap){
                spawnList.Add(position);
            }
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (WallTypesHelper.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
            upWalls.Add(position);
        }else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
            rightWalls.Add(position);
        }
        else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSiderLeft;
            leftWalls.Add(position);
        }
        else if (WallTypesHelper.wallBottm.Contains(typeAsInt))
        {
            tile = wallBottom;
            downWalls.Add(position);
        }
        else if (WallTypesHelper.wallFull.Contains(typeAsInt))
        {   
            tile = wallFull;
            fullWalls.Add(position);
        }

        if (tile!=null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeASInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeASInt))
        {
            tile = wallInnerCornerDownLeft;
            leftDownCornerWalls.Add(position);
        }
        else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeASInt))
        {
            tile = wallInnerCornerDownRight;
            rightDownCornerWalls.Add(position);
        }
        else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeASInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeASInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeASInt))
        {
            tile = wallDiagonalCornerUpRight;
            rightUpCornerWalls.Add(position);
        }
        else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeASInt))
        {
            tile = wallDiagonalCornerUpLeft;
            leftUpCornerWalls.Add(position);
        }
        else if (WallTypesHelper.wallFullEightDirections.Contains(typeASInt))
        {
            tile = wallFull;
        }
        else if (WallTypesHelper.wallBottmEightDirections.Contains(typeASInt))
        {
            tile = wallBottom;
        }

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    public List<Vector2Int> GetSpawnList(){
        return spawnList;
    }
    public List<Vector2Int> GetRightWalls(){
        return rightWalls;
    }
    public List<Vector2Int> GetLeftWalls(){
        return leftWalls;
    }
    public List<Vector2Int> GetUpWalls(){
        return upWalls;
    }
    public List<Vector2Int> GetDownWalls(){
        return downWalls;
    }
    public Tilemap GetWallTilemap(){
        return wallTilemap;
    }
    public List<Vector2Int> GetLeftDownCornerWalls(){
        return leftDownCornerWalls;
    }
    public List<Vector2Int> GetRightDownCornerWalls(){
        return rightDownCornerWalls;
    }
    public List<Vector2Int> GetRightUpCornerWalls(){
        return rightUpCornerWalls;
    }
    public List<Vector2Int> GetLeftUpCornerWalls(){
        return leftUpCornerWalls;
    }
    public List<Vector2Int> GetFullWalls(){
        return fullWalls;
    }
}

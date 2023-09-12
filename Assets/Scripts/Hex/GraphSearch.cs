using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GraphSearch
{
    public static BFSResult BFSGetRange(HexGrid hexGrid, Vector3Int startPoint, int movementPoints)
    {
        Disctionary<Vector3Int, Vector3Int?> visitedNodes = new Disctionary<Vector3Int, Vector3Int?>();
        Dictionary<Vector3Int, int> costSoFar = new Dictionary<Vector3Int, int>();
        Queue<Vector3Int> nodesToVisitQueue = new Queue<Vector3Int>();

        nodesToVisitQueue.Enqueue(startPoint);
        costSoFar.Add(startPoint,0);
        visitedNodes.Add(startPoint, null);

        while (nodesToVisitQueue.Count > 0 )
        {
            Vector3Int currentNode = nodesToVisitQueue.Dequeue();
            foreach(Vector3Int neighborPosition in hexGrid.GetNeighboursFor(currentNode))
            {
                if(hexGrid.GetTileAt(neighborPosition).IsObstacle())
                    continue;
                
                int nodeCost = hexGrid.GetTileAt(neighborPosition).GetCost();
                int currentCost = costSoFar[currentNode];
                int newCost = currentCost + nodeCost;

                if(newCost <= movementPoints)
                {
                    if(!visitedNodes.ContainsKey(neighborPosition))
                    {
                        visitedNodes[neighborPosition] = currentNode;
                        costSoFar[neighborPosition] = newCost;
                        nodesToVisitQueue.Enqueue(neighborPosition);
                    }
                    else if(costSoFar{neighborPosition} > newCost)
                    {
                        costSoFar[neighborPosition] = newCost;
                        visitedNodes[neighborPosition] = currentNode;
                    }
                }
            }
        }
    }
    return new BSFResult{ vistiedNodesDict = visitedNodes};
}

 public static List<Vector3Int> GeneratePathBFS(Vector3Int destination, Disctionary<Vector3Int,Vector3Int?> vistiedNodesDict)
    {
        List<Vector3Int> path = new List<Vector3Int>();
        path.Add(current);
        while (vistiedNodesDict[current] != null)
        {
            path.Add(vistiedNodesDict[current].Value);
            current = vistiedNodesDict[current].Value;
        }
        path.Reverse();
        return path.Skip(1).ToList();
    }

    public struct BSFResult
    {
        public Dictionary<Vector3Int, Vector3Int?> vistiedNodesDict;

        public List<Vector3Int> GetPathTo(Vector3Int destination)
        {
            if(vistiedNodesDict.ContainsKey(destination) == false)
                return new List<Vector3Int>();
            return GraphSearch.GeneratePathBFS(destination, vistiedNodesDict);
        }

        public bool IsHexPositionInRange(Vector3Int position)
        {
            return vistiedNodesDict.ContainsKey(position);
        }

        public IEnumerable<Vector3Int> GetRangePositions()
            => vistiedNodesDict.Keys;
    }

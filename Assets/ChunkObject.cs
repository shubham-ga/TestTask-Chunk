using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Available,
    Current,
    Completed
}

public class ChunkObject : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer floor;
    int no;
    public void RemoveWall(int wallToRemove)
    {
        walls[wallToRemove].gameObject.SetActive(false);
    }
    public void OnEnable()
    {
        for (int i = 0; i <1; i++)
        {
            Debug.Log(no);
            walls[GetWallNumber(no)].gameObject.SetActive(true);
        }

    }

    public int GetWallNumber(int addnimber)
    {
        no = Random.Range(0, walls.Length);
        if (no == addnimber)
        {
            return GetWallNumber(no);
        }
        return no;
    }
    public void SetState(NodeState state)
    {
        //switch (state)
        //{
        //    case NodeState.Available:
        //        floor.material.color = Color.white;
        //        break;
        //    case NodeState.Current:
        //        floor.material.color = Color.yellow;
        //        break;
        //    case NodeState.Completed:
        //        floor.material.color = Color.blue;
        //        break;
        //}
    }
}

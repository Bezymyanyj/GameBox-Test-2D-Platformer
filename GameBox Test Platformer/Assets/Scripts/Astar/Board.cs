using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board: MonoBehaviour {
    public int width;
    public int height;
    public GameObject cellPrefab;
    Cell [,]board;
    public float step;

    void Awake() {
        CreateBoard ();
    }

    void CreateBoard() {
        board = new Cell[width,height];
        for (int i = 0; i < height; i++)
        for (int j = 0; j < width; j++) {
            GameObject cell = GameObject.Instantiate(
                cellPrefab,
                new Vector3(j* step, i * step, 0),
                Quaternion.identity) as GameObject;
            cell.transform.parent = transform;
            Cell c = cell.GetComponent<Cell>();
            c.coordinates = new Vector2(j * step, i * step);
            board[j,i] = c;
        }
    }

    protected List<Cell> FindPath(Cell origin, Cell goal) {
        AStar pathFinder = new AStar();
        pathFinder.FindPath (origin, goal, board, false);
        return pathFinder.CellsFromPath ();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateRandomObstacles
{
    public static void GenerateRandomGrid(int width, int height, float obstacleProbability)
    {
        // Get the grid from the Pathfinding component on Maze object.
        Pathfinding pathfinding = GameObject.Find("Maze").GetComponent<Pathfinding>();
        pathfinding.grid = new int[width, height];

        // Initialize random number generator.
        System.Random rand = new System.Random();

        // Go through each cell in the grid.
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Set cell to obstacle based on probability.
                if (rand.NextDouble() < obstacleProbability / 100f)
                {
                    pathfinding.grid[y, x] = 1;
                }
                else
                {
                    pathfinding.grid[y, x] = 0;
                }
            }
        }

        // Set start cell to 0.
        pathfinding.grid[pathfinding.start.x, pathfinding.start.y] = 0;

        // Set end cell to 0.
        pathfinding.grid[pathfinding.goal.x, pathfinding.goal.y] = 0;

    }
}

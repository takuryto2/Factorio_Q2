using UnityEngine;
using UnityEngine.SceneManagement;

public interface IPlaceable
{
    int sizeX { get; }
    int sizeY { get; }
    float X { get; set; }
    float Y { get; set; }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public interface IPlaceable
{
    int sizeX { get; set; }
    int sizeZ { get; set; }
    float X { get; set; }
    float Z { get; set; }

}

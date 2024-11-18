public interface IPlaceable
{
    int sizeX { get =>sizeX; set =>sizeX=value; }
    int sizeZ { get => sizeZ; set => sizeZ = value; }
    int gridScaleX { get; set; }
    int gridScaleZ { get; set; }
    float posX { get; set; }
    float posZ { get; set; }

    void AdjustSize(int gridX, int gridZ);
}

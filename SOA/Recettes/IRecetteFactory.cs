namespace SOA.Recettes
{
    public interface IRecetteFactory
    {
        RecetteBase Create(string recetteName);
    }
}

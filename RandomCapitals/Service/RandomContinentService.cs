namespace RandomContinent.Service
{
    public class RandomContinentService
    {
        public int[] GenerateRandomCoordinates()
        {
            Random rand = new Random();
            int x1 = rand.Next(18);
            int y1 = rand.Next(9);

            int[] coordinates = new int[] { x1, y1 };
            return coordinates;
        }

    }
}

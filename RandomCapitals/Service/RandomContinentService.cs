namespace RandomContinent.Service
{
    public class RandomContinentService
    {
        public int[][] GenerateRandomCoordinates()
        {
            Random rand = new Random();
            int[][] coordinates = new int[2][];

            // Generate the first coordinate
            int x1, y1;
            x1 = rand.Next(18);
            y1 = rand.Next(9);
            coordinates[0] = new int[] { x1, y1 };

            // Generate the second coordinate
            int x2, y2;
            do
            {
                x2 = rand.Next(18);
                y2 = rand.Next(9);
            } while (x2 == x1 && y2 == y1);

            coordinates[1] = new int[] { x2, y2 };

            return coordinates;
        }
    }
}

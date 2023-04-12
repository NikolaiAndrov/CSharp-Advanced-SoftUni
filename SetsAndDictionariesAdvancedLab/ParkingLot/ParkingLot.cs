public class ParkingLot
{
    public static void Main()
    {
        HashSet<string> parking = new HashSet<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] args = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string direction = args[0];
            string plate = args[1];

            if (direction == "IN")
            {
                parking.Add(plate);
            }
            else if (direction == "OUT")
            {
                parking.Remove(plate);
            }
        }

        if (parking.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
        }
        else if (parking.Count > 0)
        {
            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
        }
    }
}
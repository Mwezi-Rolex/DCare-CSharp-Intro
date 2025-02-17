class Program{
    static void Main(string[] args){

        List<Track> tracks = new List<Track>();

        while(true){
            Console.WriteLine("Enter track details (weight and destination), or type 'stop' to exit");

            string input = Console.ReadLine();

            if(input.ToLower() == "stop"){
                break;
            }

            string[] parts = input.Split(' ');

            if(parts.Length != 2){
                Console.WriteLine("Invalid input format. Please enter weight and destination separated by a space");
                continue;
            }

            if(!int.TryParse(parts[0], out int weight)){
                Console.WriteLine("Invalid weight. Please enter a valid integer");
            }

            tracks.Add(new Track(weight, parts[1]));
        }
    
        int totalWeight = 0;

        foreach(Track track in tracks){
            totalWeight = track.Weight;
        }

        Console.WriteLine($"Total weight of trucks: {totalWeight}");
        Console.WriteLine($"Total number of trucks: {tracks.Count}");
        Console.WriteLine($"Destination");

        Dictionary<string, int> destinationWeight = new Dictionary<string, int>();

        foreach(Track track in tracks){
            if(destinationWeight.ContainsKey(track.Destination)){
                destinationWeight[track.Destination] += track.Weight;
            }
            else{
                destinationWeight[track.Destination] = track.Weight;
            }

            foreach(var entry in destinationWeight){
                Console.WriteLine($"- {entry.Key}: {entry.Value}");
        }

    }
}

class Track{
    public int Weight{get; set;}
    public string Destination{get; set;}
    public Track(int weight, string destination){
        Weight = weight;
        Destination = destination;
    }
}

}

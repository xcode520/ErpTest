namespace ErpModels.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ClientModel Client { get; set; }
    }
}

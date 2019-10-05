namespace ErpModels.Models
{
    public class ClientModel
    {
        public string Id { get; set; }

        public PersonModel IdNavigation { get; set; }
    }
}

namespace ErpModels.ModelItems
{
    public class ClientItem
    {
        public string Id { get; set; }

        public PersonItem IdNavigation { get; set; }
    }
}

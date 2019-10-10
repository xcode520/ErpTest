namespace ErpCore.Domain
{
    public partial class Client
    {
        public string Id { get; set; }

        public virtual Person IdNavigation { get; set; }
    }
}

namespace CustomerManagement.RequestModels.CommandRequests
{
    public class SaveCustomerRequestModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}

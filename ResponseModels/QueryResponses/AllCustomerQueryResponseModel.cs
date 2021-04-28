namespace CustomerManagement.ResponseModels.QueryResponses
{
    public class AllCustomerQueryResponseModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}

namespace Api_VersionControl.DTO
{
    public class UsersResponseData
    {
        public User[]? data {  get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}

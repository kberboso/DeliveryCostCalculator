namespace DeliveryCostCalculator.Business.Entities
{
    public class BaseEntity
    {
        public ResponseCode Response { get; set; }
        public string Message { get; set; }

        public BaseEntity()
        {
            Response = ResponseCode.Ok;
            Message = "";
        }
    }

    public enum ResponseCode
    {
        Ok = 1,
        Fail = 0,
        Error = -1
    }
}

namespace ApiDal.Entities
{
    public class ResponseMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
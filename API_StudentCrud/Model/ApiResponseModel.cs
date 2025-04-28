namespace API_StudentCrud.Model
{
    public class ApiResponseModel
    {
        public class ApiGetResponseModel<T>
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public int TotalRecord { get; set; }
            public T Result { get; set; }
            public object ExtraData { get; set; }
        }
    }
}

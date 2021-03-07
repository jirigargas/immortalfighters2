namespace ImmortalFighters.WebApp.ApiModels
{
    public class Response : IResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        private Response(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }

        public static Response ValidResponse() => new Response(true, "");

        public static Response InvalidResponse(string message) => new Response(false, message);
    }

    public class Response<T> : IResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }

        private Response(bool isValid, string message, T data)
        {
            IsValid = isValid;
            Message = message;
            Data = data;
        }

        public static Response<T> InvalidResponse(string message) => new Response<T>(false, message, null);

        public static Response<T> ValidResponse(T data) => new Response<T>(true, "", data);
    }
}

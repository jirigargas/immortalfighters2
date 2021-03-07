namespace ImmortalFighters.WebApp.ApiModels
{
    public interface IResponse
    {
        bool IsValid { get; set; }
        string Message { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
    }
}

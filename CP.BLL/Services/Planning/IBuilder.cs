namespace CP.BLL.Services.Planning
{
    public interface IBuilder<T> where T : class
    {
        T Build();
    }
}

using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Models.Seed
{
    public interface ISeeder
    {
        Task Seed();
    }
}

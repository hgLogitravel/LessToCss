using System.Threading.Tasks;

namespace LessToCss
{
    public interface IRenderService
    {
        Task<Output> Render(string lessData);
    }
}

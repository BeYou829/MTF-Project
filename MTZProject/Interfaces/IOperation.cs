using MTZProject.Models;

namespace MTZProject.Interfaces
{
    public interface IOperation
    {
        OutputProcessVM Processing(InputProcessVM model)
        {
            return new OutputProcessVM();
        }
    }
}

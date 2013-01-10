using ExampleApplication.Models;
using WinFormsMvp;

namespace ExampleApplication.Views
{
    public interface IProjectChooser : IView<ChooseProjectModel>
    {
        Project SelectedProject { get; }
    }
}

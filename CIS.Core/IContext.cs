using CIS.Purview.ViewModel;

namespace CIS.Core
{
    public interface IContext
    {
        Session Session { get; set; }
    }
}
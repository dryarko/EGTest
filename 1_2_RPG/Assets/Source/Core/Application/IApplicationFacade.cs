// IApplicationFacade.cs
// created by Yaroslav Nevmerzhytskyi

using Core.AssetManagement;
using Core.UI.PopUp;

namespace Core.Application
{
    internal interface IApplicationFacade
    {
        AssetManager AssetManager
        {
            get;
        }
        
        PopUpFactory PopUpFactory
        {
            get;
        }
    }
}
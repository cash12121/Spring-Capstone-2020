using log4net;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Creator: 2/11/2020
    /// Approver: Steven Cardona
    /// 
    /// This class is a helper method to call when something needs logged in the PresentationLayer
    /// </summary>
    public class LogHelper
    {
        public static readonly ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}

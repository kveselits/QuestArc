using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace QuestArc.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new QuestArc.App(), args);
            host.Run();
        }
    }
}

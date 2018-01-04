using System;

namespace Anarkanoid
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (AnarkanoidGame game = new AnarkanoidGame())
            {
                game.Run();
            }
        }
    }
#endif
}


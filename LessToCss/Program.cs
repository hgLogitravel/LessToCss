using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LessToCss
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            if (!args.Any() && !args.Any(p => p.Equals("-n")) || args[0] == "-h" || args[0]=="--help")
            {
                Console.WriteLine("");
                Console.WriteLine(@"Usage: LessToCss -n E:\mydirectory\bylogitravel\test\test_hermes.less");
                Console.WriteLine(@"Usage: LessToCss -n E:\mydirectory\bylogitravel\test\test_hermes.less -o result.css");
                Console.WriteLine(@"Usage: LessToCss -n E:\mydirectory\bylogitravel\test\test_hermes.less -o result.css -p e:\");
                Console.WriteLine("");
                Console.WriteLine("Options:");
                Console.WriteLine("");
                Console.WriteLine("-h|--help        Display help");
                Console.WriteLine("-n               Less file for convert to css");
                Console.WriteLine("-o               Css file output");
                Console.WriteLine("-p               Path file output");
                return;
            }
          
            var filePath = string.Empty;
            var fileOutput = string.Empty;
            var path = string.Empty;
            for (int i = 0; i < args.Length - 1; i++)
            {
                string parameterName = args[i];
                switch (parameterName)
                {
                    case "-n":
                        filePath = args[i + 1];
                        break;
                    case "-o": // output file
                        fileOutput = args[i + 1];
                        break;
                    case "-p": // path for output file
                        path = args[i + 1];
                        break;
                }
            }
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IRenderService, RenderService>();
                serviceProvider.AddNodeServices(o => o.ProjectPath = Directory.GetCurrentDirectory());

                var build = serviceProvider.BuildServiceProvider();
                var render = build.GetService<IRenderService>();

                var r = await render.Render(filePath);
                if (!string.IsNullOrWhiteSpace(fileOutput))
                {
                    await File.WriteAllTextAsync($"{path}{fileOutput}", r.css);
                }
                else
                {
                    Console.Write(r.css);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}

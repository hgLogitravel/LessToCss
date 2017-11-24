using Microsoft.AspNetCore.NodeServices;
using System;
using System.Threading.Tasks;

namespace LessToCss
{
    public struct Output
    {
        public string css;
        public string[] include;
    }
    public class RenderService : IRenderService, IDisposable
    {
        private readonly INodeServices _nodeServices;
        private bool _disposed;
        public RenderService(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _nodeServices.Dispose();
            }

            _disposed = true;
        }


        public Task<Output> Render(string lessData)
        {
            return _nodeServices.InvokeAsync<Output>("compiler.js", lessData);
        }
    }
}

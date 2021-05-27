using System;
using System.Collections.Generic;
using System.Net;

namespace WebDAVSharp.Server.Adapters
{
    /// <summary>
    /// This 
    /// <see cref="IHttpListenerContext" /> implementation wraps around a
    /// <see cref="HttpListenerContext" /> instance.
    /// </summary>
    public sealed class HttpListenerContextAdapter : IHttpListenerContext
    {
        #region Private Variables

        private readonly HttpListenerContext _context;
        private readonly HttpListenerRequestAdapter _request;
        private readonly HttpListenerResponseAdapter _response;
        private readonly Dictionary<String, Object> _contextData;

        #endregion

        #region Public Functions

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpListenerContextAdapter" /> class.
        /// </summary>
        /// <param name="context">The <see cref="HttpListenerContext" /> to adapt for WebDAV#.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <exception cref="ArgumentNullException"><paramref name="context" /> is <c>null</c>.</exception>
        public HttpListenerContextAdapter(HttpListenerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
            _request = new HttpListenerRequestAdapter(context.Request);
            _response = new HttpListenerResponseAdapter(context.Response);
            _contextData = new Dictionary<string, object>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the internal instance that was adapted for WebDAV#.
        /// </summary>
        /// <value>
        /// The adapted instance.
        /// </value>
        public HttpListenerContext AdaptedInstance
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// Gets the <see cref="IHttpListenerRequest" /> request adapter.
        /// </summary>
        public IHttpListenerRequest Request
        {
            get
            {
                return _request;
            }
        }

        /// <summary>
        /// Gets the <see cref="IHttpListenerResponse" /> response adapter.
        /// </summary>
        public IHttpListenerResponse Response
        {
            get
            {
                return _response;
            }
        }

        /// <summary>
        /// Get context data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetContextData(string key)
        {
            Object data;
            if (_contextData.TryGetValue(key, out data))
                return data;

            return null;
        }

        /// <summary>
        /// Set context data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void SetContextData(string key, object data)
        {
            _contextData[key] = data;
        }

        #endregion
    }
}
namespace BootstrapMvcHelperExtensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// Container for the buttons
    /// </summary>
    public class BootstrapButtonContainer : IDisposable
    {
         /// <summary>
        /// field to store the writer
        /// </summary>
        private readonly TextWriter writer;
        
        /// <summary>
        /// field to determine if item has been disposed
        /// </summary>
        private bool disposed;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapButtonContainer"/> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        public BootstrapButtonContainer(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }

            this.writer = viewContext.Writer;
        }

        /// <summary>
        /// Ends the container.
        /// </summary>
        public void EndContainer()
        {
            this.Dispose(true);
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.disposed = true;
                this.writer.Write(Common.GetButtonContainer().ToString(TagRenderMode.EndTag));
            }
        }
    }
}

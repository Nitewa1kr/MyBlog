[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(myBlogMain.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(myBlogMain.App_Start.NinjectWebCommon), "Stop")]

namespace myBlogMain.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Moq;
    using myBlog.Domain.Repositories;
    using myBlog.Domain.Entities;
    using System.Collections.Generic;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            Mock<IPostRepo> MockPosts = new Mock<IPostRepo>();
            MockPosts.Setup(mp => mp.Posts).Returns(new List<Post>
            {
                new Post {
                    TITLE = "Test Title",
                    POST_AUTHOR = "Test Author",
                    POST_BODY = "Test Post",
                    P_DATE_TIME = Convert.ToDateTime(DateTime.Now)
                }
            });
            kernel.Bind<IPostRepo>().ToConstant(MockPosts.Object);
        }        
    }
}

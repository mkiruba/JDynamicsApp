﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JDynamicsApp.Startup))]

namespace JDynamicsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

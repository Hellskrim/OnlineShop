using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using OnlineShop.CSharpCode;

[assembly: OwinStartup(typeof(OnlineShop.Startup))]

namespace OnlineShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        Order order1 = new Order(1, 100);
        User user = new User("at@gmail.com","zaq12wsx");



    }
}

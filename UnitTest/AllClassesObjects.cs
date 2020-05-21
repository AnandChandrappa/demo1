using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.PageObjects;

namespace UnitTest
{
    class AllClassesObjects : BaseTest
    {
        public home homePage = new home(driver);
        public login loginPage = new login(driver);
        public searchResults searchPage = new searchResults(driver);
        public productDetail productDetailPage = new productDetail(driver);
        public basket basketPage = new basket(driver);        
        
    }
}
